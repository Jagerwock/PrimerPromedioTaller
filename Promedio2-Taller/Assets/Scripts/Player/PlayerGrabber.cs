using UnityEngine;

public class PlayerGrabber : MonoBehaviour
{
    public static PlayerGrabber Instance { get; private set; }
    [Header("Referencias")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform holdPoint;
    [Header("Configuración")]
    [SerializeField] private KeyCode dropKey = KeyCode.G;
    [SerializeField] private float dropForwardOffset = 0.6f;
    public Grabbable CurrentlyHeld { get; private set; }
    public bool IsCarrying => CurrentlyHeld != null;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>() ?? GetComponent<Camera>();
    }
    private void Update()
    {
        if (IsCarrying && Input.GetKeyDown(dropKey))
        {
            Drop();
        }
    }
    public void PickUp(Grabbable grabbable)
    {
        if (IsCarrying)
            Drop();
        CurrentlyHeld = grabbable;
        grabbable.AttachTo(holdPoint);
    }
    public void Drop()
    {
        if (!IsCarrying)
            return;
        Vector3 dropPosition = playerCamera.transform.position + playerCamera.transform.forward * dropForwardOffset;
        CurrentlyHeld.Release(dropPosition, Quaternion.identity);
        CurrentlyHeld = null;
    }
}