using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToSave : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string id;

    [ContextMenu("Generate id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool state = true;

    public void LoadData(GameData data)
    {
        data.solvedPuzzles.TryGetValue(id, out state);
    }

    public void SaveData(ref GameData data)
    {
        if (data.solvedPuzzles.ContainsKey(id))
        {
            data.solvedPuzzles.Remove(id);
        }
        data.solvedPuzzles.Add(id, state);
    }
}
