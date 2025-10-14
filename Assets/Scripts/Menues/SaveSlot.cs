using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileID = "";
    public string currentScene;

    [Header("Content")]
    [SerializeField] private GameObject noData;
    public GameObject hasData;
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private Button slotButton;

    [Header("Clear Data")]
    [SerializeField] private Button deleteButton;

    private void Awake()
    {
        slotButton = this.GetComponent<Button>();
    }

    public void SetData (GameData data)
    {
        if (data == null)
        {
            noData.SetActive(true);
            hasData.SetActive(false);
            currentScene = "Scene Two";
            deleteButton.gameObject.SetActive(false);
        }
        else
        {
            noData.SetActive(false);
            hasData.SetActive(true);
            deleteButton.gameObject.SetActive(true);

            lvlText.text = data.scene;
            currentScene = data.scene;
        }
    }

    public string GetProfileID()
    {
        return this.profileID;
    }

    public void SetInteractable(bool inter)
    {
        slotButton.interactable = inter;
        deleteButton.interactable = inter;
    }
}
