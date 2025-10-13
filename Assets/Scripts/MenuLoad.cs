using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoad : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string sceneToLoad;

    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;

    public void LoadData(GameData data)
    {
        this.sceneToLoad = data.scene;
    }

    public void SaveData(ref GameData data)
    {
        data.scene = this.sceneToLoad;
    }

    public void NewGame()
    {
        DisableButtons();
        Debug.Log("start new game");
        DataPersistenceManager.Instance.NewGame();
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    public void Continue()
    {
        DisableButtons();
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

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

