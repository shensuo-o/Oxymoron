using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    private bool isPaused = false;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject optionsBackButton;
    [SerializeField] private GameObject mainBackButton;
    [SerializeField] private GameObject optionTitle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
            {
                PauseGame();
                Back();
            }
        }
    }

    public void Options()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        optionsBackButton.SetActive(false);
        optionTitle.SetActive(true);
        optionTitle.GetComponent<TextMeshProUGUI>().text = "Options";
        mainBackButton.SetActive(true);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void Back()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
        optionsBackButton.SetActive(false);
        optionTitle.SetActive(false);
        mainBackButton.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void Audio()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        optionsBackButton.SetActive(true);
        optionTitle.SetActive(true);
        optionTitle.GetComponent<TextMeshProUGUI>().text = "Audio";
        mainBackButton.SetActive(false);
        audioPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void Controls()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        optionsBackButton.SetActive(true);
        optionTitle.SetActive(true);
        optionTitle.GetComponent<TextMeshProUGUI>().text = "Controls";
        mainBackButton.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}

