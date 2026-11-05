using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Interacción")]
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactMask = ~0;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("Referencias")]
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraLook cameraLook;

    private GameObject avisoVisible;

    public bool InputLocked { get; private set; }

    private void Awake()
    {
        if (player == null) player = GetComponentInParent<PlayerController>();
        if (cameraLook == null) cameraLook = GetComponent<CameraLook>();
    }

    private void Update()
    {
        Interactable objetivo = InputLocked ? null : FindInteractable();
        MostrarAviso(objetivo != null ? objetivo.Aviso : null);
        if (objetivo == null)
            return;

        if (Input.GetKeyDown(interactKey))
            objetivo.Interact(this);
        else if (Input.GetKeyDown(KeyCode.R))
            objetivo.InteractAlternate(this);
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

    private void MostrarAviso(GameObject aviso)
    {
        if (aviso == avisoVisible)
            return;

        if (avisoVisible != null)
            avisoVisible.SetActive(false);

        avisoVisible = aviso;
        if (avisoVisible != null)
            avisoVisible.SetActive(true);
    }
}
