using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
   public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Hay mas de un DataPersistenceManager.");
        }
        Instance = this;
    }

    public void NewGame()
    {

    }

    public void LoadGame()
    {

    }

    public void SaveGame()
    {

    }
}
