using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string sceneToLoad;

    public void LoadData(GameData data)
    {
        this.sceneToLoad = data.scene;
    }

    public void SaveData(ref GameData data)
    {
        data.scene = this.sceneToLoad;
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

