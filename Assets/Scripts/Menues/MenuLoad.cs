using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoad : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string sceneToLoad;

    [Header("Menu Navigation")]

    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject ControlsPanel;
    [SerializeField] private GameObject AudioPanel;
    [SerializeField] private GameObject QuitPanel;

    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        DisableButtonsPerData();
    }

    private void DisableButtonsPerData()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            continueButton.interactable = false;
        }
    }

    public void LoadData(GameData data)
    {
        this.sceneToLoad = data.scene;
    }

    public void SaveData(GameData data)
    {
        data.scene = this.sceneToLoad;
    }

    public void NewGame()
    {
        saveSlotsMenu.ActivateMenu();
        OptionsPanel.SetActive(false);
    }

    public void Continue()
    {
        DisableButtons();
        DataPersistenceManager.Instance.SaveGame();
        Debug.Log("continue game");
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    public void Options()
    {
        saveSlotsMenu.DeactivateMenu();
        ActivateMenu();
        OptionsPanel.SetActive(true);
        QuitPanel.SetActive(false);
    }

    public void Audio()
    {
        AudioPanel.SetActive(true);
        ControlsPanel.SetActive(false);
        QuitPanel.SetActive(false);
    }

    public void Controls()
    {
        ControlsPanel.SetActive(true);
        AudioPanel.SetActive(false);
        QuitPanel.SetActive(false);
    }

    private void DisableButtons()
    {
        newGameButton.interactable = false;
        continueButton.interactable = false;
    }

    public void LoadSandbox()
    {
        SceneManager.LoadScene("Sandbox");
    }

    public void LoadPrototype()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ActivateMenu()
    {
        DisableButtonsPerData();
    }

    public void Quit()
    {
        saveSlotsMenu.DeactivateMenu();
        ActivateMenu();
        QuitPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    public void DontExit()
    {
        QuitPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

