using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Interacción")]
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactMask = ~0;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("UI")]
    [SerializeField] private TMP_Text promptText;

    [Header("Referencias")]
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraLook cameraLook;

    private Interactable _current;

    public bool InputLocked { get; private set; }

    private void Awake()
    {
        if (player == null) player = GetComponentInParent<PlayerController>();
        if (cameraLook == null) cameraLook = GetComponent<CameraLook>();
        SetPrompt("");
    }

    private void Update()
    {
        if (InputLocked)
        {
            _current = null;
            SetPrompt("");
            return;
        }

        _current = FindInteractable();

        if (_current != null)
        {
            SetPrompt(_current.Prompt);

            if (Input.GetKeyDown(interactKey))
                _current.Interact(this);
        }
        else
        {
            SetPrompt("");
        }
    }

    private Interactable FindInteractable()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask, QueryTriggerInteraction.Ignore))
        {
            Interactable found = hit.collider.GetComponentInParent<Interactable>();
            if (found != null && found.CanInteract)
                return found;
        }

        return null;
    }

    public void SetPlayerControl(bool enabled)
    {
        InputLocked = !enabled;

        if (player != null) player.CanMove = enabled;
        if (cameraLook != null) cameraLook.CanLook = enabled;

        if (CursorLockManager.Instance != null)
        {
            if (enabled) CursorLockManager.Instance.LockCursor();
            else CursorLockManager.Instance.UnlockCursor();
        }
    }

    private void SetPrompt(string text)
    {
        if (promptText != null)
            promptText.text = text;
    }
}