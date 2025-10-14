using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool createDataIfNull = false;

    [Header("FileStorageConfig")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    public static DataPersistenceManager Instance { get; private set; }
    private List<IDataPersistance> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    private string selectedProfile = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Hay mas de un DataPersistenceManager. Borrando el mas nuevo.");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        InitializeProfile();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogWarning("Scene Loaded");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void ChangeProfileID(string newProfile)
    {
        this.selectedProfile = newProfile;

        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //Load saved data using data handler
        this.gameData = dataHandler.Load(selectedProfile);

        if (this.gameData == null && createDataIfNull)
        {
            NewGame();
        }

        //If gameData == null then go to new game
        if (gameData == null)
        {
            Debug.Log("No game data found. Cant Load.");
            return;
        }

        //Push loaded data to scripts that need said data
        foreach (IDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No game data found. Cant Save.");
            return;
        }
        //Pass the data to scripts for update.
        foreach (IDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        //Save data to file bya the dataHandler.
        dataHandler.Save(gameData, selectedProfile);
    }

    public void Delete(string ProfileID)
    {
        dataHandler.Delete(ProfileID);
        InitializeProfile();
        LoadGame();
    }

    private void InitializeProfile()
    {
        this.selectedProfile = dataHandler.GetRecentProfile();
    }

    private List<IDataPersistance> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistenceObject = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistenceObject);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfiles()
    {
        return dataHandler.LoadAllProfiles();
    }
}
