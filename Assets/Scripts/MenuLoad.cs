using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    public void LoadSandbox()
    {
        SceneManager.LoadScene("Sandbox");
    }

    public void LoadPrototype()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

