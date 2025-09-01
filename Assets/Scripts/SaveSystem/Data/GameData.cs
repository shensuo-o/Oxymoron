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

    //Default values:
    public GameData()
    {
        this.hp = 100;
        this.playerPosition = new Vector3(-274, 3, 0);
        solvedPuzzles = new SerializedDictionary<string, bool>();
    }
}
