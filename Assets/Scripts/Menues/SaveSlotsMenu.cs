using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MenuLoad mainMenu;
    [SerializeField] private Button back;

    private SaveSlot[] saveSlots;

    [SerializeField] private bool isLoading;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void SaveSlot(SaveSlot slot)
    {
        DisableButtons();

        DataPersistenceManager.Instance.ChangeProfileID(slot.GetProfileID());

        if (!slot.hasData.activeSelf)
        {
            DataPersistenceManager.Instance.NewGame();
        }

        SceneManager.LoadSceneAsync(slot.currentScene);
    }

    public void Back()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);

        Dictionary<string, GameData> profilesData = DataPersistenceManager.Instance.GetAllProfiles();

        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesData.TryGetValue(saveSlot.GetProfileID(), out profileData);
            saveSlot.SetData(profileData);
        }
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        back.interactable = false;
    }
}
