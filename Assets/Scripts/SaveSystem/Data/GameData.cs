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
    public SerializedDictionary<string, bool> solvedPuzzles;
    public SerializedDictionary<string, int> statuesOrder;
    public string scene;

    //Default values:
    public GameData()
    {
        this.hp = 100;
        this.playerPosition = Vector3.zero;
        solvedPuzzles = new SerializedDictionary<string, bool>();
        statuesOrder = new SerializedDictionary<string, int>();
        this.scene = "Scene Two";
        
    }
}
