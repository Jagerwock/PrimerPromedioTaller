using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private HealthBar playerBar;
    [SerializeField] private HealthBar bossBar;
    [SerializeField] private Health boss;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    [SerializeField] private string menuScene = "MenuPrincipal";
    [SerializeField] private string firstLevel = "Nivel-1";
    [SerializeField] private string nextLevel = "Nivel-2";
    [SerializeField] private GameObject events;

    private bool finished;

    private void OnEnable()
    {
        Connect(player);
        ConnectBoss(boss);
    }

    private void Start()
    {
        if (EventSystem.current == null && events != null) events.SetActive(true);
        if (player == null) Connect(FindFirstObjectByType<PlayerHealth>());
    }

    private void OnDisable()
    {
        if (player != null) player.OnPlayerDied -= ShowLose;
        if (boss != null) boss.OnHealthChanged -= OnBossHealthChanged;
    }

    public void Connect(PlayerHealth target)
    {
        if (player != null) player.OnPlayerDied -= ShowLose;
        player = target;
        playerBar.Bind(player);

        if (player == null) return;
        if (isActiveAndEnabled) player.OnPlayerDied += ShowLose;
        if (player.IsDead) ShowLose();
    }

    public void ConnectBoss(Health target)
    {
        if (boss != null) boss.OnHealthChanged -= OnBossHealthChanged;
        boss = target;
        bossBar.Bind(boss);

        if (boss == null) return;
        if (isActiveAndEnabled) boss.OnHealthChanged += OnBossHealthChanged;
        if (boss.IsDead) ShowWin();
    }

    private void OnBossHealthChanged(float current, float max)
    {
        if (max > 0f && current <= 0f) ShowWin();
    }

    public void ShowWin()
    {
        if (finished || boss == null || boss.MaxHealth <= 0f || boss.CurrentHealth > 0f
            || player == null || player.IsDead || player.CurrentHealth <= 0f) return;

        finished = true;
        lose.SetActive(false);
        win.SetActive(true);
        bossBar.Hide();
        Time.timeScale = 0f;
        ShowCursor();
    }

    public void ShowLose()
    {
        if (finished || player == null || !player.IsDead) return;

        finished = true;
        win.SetActive(false);
        lose.SetActive(true);
        Time.timeScale = 0f;
        ShowCursor();
    }

    public void Retry()
    {
        Load(SceneManager.GetActiveScene().path);
    }

    public void Restart()
    {
        Load(firstLevel);
    }

    public void NextLevel()
    {
        if (finished || player == null || player.IsDead || player.CurrentHealth <= 0f
            || !Application.CanStreamedLevelBeLoaded(nextLevel)) return;
        finished = true;
        Load(nextLevel);
    }

    public void Menu()
    {
        Load(menuScene);
    }

    private void Load(string scene)
    {
        if (string.IsNullOrWhiteSpace(scene) || !Application.CanStreamedLevelBeLoaded(scene))
            return;

        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
