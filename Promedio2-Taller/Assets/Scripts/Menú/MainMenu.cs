using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Principal");
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
