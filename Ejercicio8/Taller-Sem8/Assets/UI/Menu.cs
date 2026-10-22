using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private string firstLevel;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject credits;
    [SerializeField] private Button play;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Back();
        play.interactable = !string.IsNullOrWhiteSpace(firstLevel)
            && Application.CanStreamedLevelBeLoaded(firstLevel);
    }

    public void Play()
    {
        if (string.IsNullOrWhiteSpace(firstLevel)
            || !Application.CanStreamedLevelBeLoaded(firstLevel)) return;

        Time.timeScale = 1f;
        SceneManager.LoadScene(firstLevel);
    }

    public void Credits()
    {
        main.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        credits.SetActive(false);
        main.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
