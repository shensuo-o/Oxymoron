using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;

[System.Serializable]

public class GameData
{
    public float hp;
    public Vector3 playerPosition;
    public SerializedDictionary<string, bool> solvedPuzzles;
    public string scene;

    //Default values:
    public GameData()
    {
        this.hp = 100;
        this.playerPosition = Vector3.zero;
        solvedPuzzles = new SerializedDictionary<string, bool>();
        this.scene = "Scene One";
    }
}
