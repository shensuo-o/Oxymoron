using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("FileStorageConfig")]

    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption;

    private GameData gameData;
    public static DataPersistenceManager Instance { get; private set; }
    private List<IDataPersistance> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Hay mas de un DataPersistenceManager.");
        }
        Instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //Load saved data using data handler
        this.gameData = dataHandler.Load();

        //If gameData == null then go to new game
        if (gameData == null)
        {
            Debug.Log("No game data found. Creating new game");
            NewGame();
        }

        //Push loaded data to scripts that need said data
        foreach (IDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //Pass the data to scripts for update.
        foreach (IDataPersistance dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        //Save data to file bya the dataHandler.
        dataHandler.Save(gameData);
    }

    private List<IDataPersistance> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistenceObject = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistenceObject);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
