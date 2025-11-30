using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;

[System.Serializable]

public class GameData
{
    public long lastUpdated;
    public float hp;
    public Vector3 playerPosition;
    public Vector3 companionPosition;
    public SerializedDictionary<string, bool> solvedPuzzles;
    public SerializedDictionary<string, int> statuesOrder;
    public string scene;

    //Default values:
    public GameData()
    {
        this.hp = 100;
        this.playerPosition = new Vector3 (-33, 3, 0);
        this.companionPosition = new Vector3(-39, 4, 0);
        solvedPuzzles = new SerializedDictionary<string, bool>();
        statuesOrder = new SerializedDictionary<string, int>();
        this.scene = "Scene Two";
        
    }
}
