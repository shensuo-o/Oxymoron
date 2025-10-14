using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoad : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string sceneToLoad;

    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

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
        this.DeactivateMenu();
    }

    public void Continue()
    {
        DisableButtons();
        DataPersistenceManager.Instance.SaveGame();
        Debug.Log("continue game");
        SceneManager.LoadSceneAsync(sceneToLoad);
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
        this.gameObject.SetActive(true);
        DisableButtonsPerData();
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

