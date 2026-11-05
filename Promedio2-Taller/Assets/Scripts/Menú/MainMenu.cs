using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject journeyPanel;

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        journeyPanel.SetActive(true);
    }

    public void StartJourney()
    {
        SceneManager.LoadScene("Principal");
    }

    public void ShowCredits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsPanel.SetActive(false);
        journeyPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
