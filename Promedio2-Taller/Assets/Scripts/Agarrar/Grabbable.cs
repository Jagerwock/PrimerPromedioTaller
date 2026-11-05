using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Grabbable : InteractableBase
{
    [Header("Capa mientras se carga")]
    [SerializeField] private string carriedLayerName = "Carried";
    private Rigidbody _rb;
    private Collider _collider;
    private int _originalLayer;
    private int _carriedLayer;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _carriedLayer = LayerMask.NameToLayer(carriedLayerName);
        if (_carriedLayer == -1)
            Debug.LogWarning($"[Grabbable] No existe la capa '{carriedLayerName}'. Créala en Project Settings > Tags and Layers.");
    }
    protected override void OnInteract(PlayerInteractor interactor)
    {
        PlayerGrabber.Instance.PickUp(this);
    }
    public void AttachTo(Transform holdPoint)
    {
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.isKinematic = true;
        if (_collider != null)
            _collider.enabled = false;
        if (_carriedLayer != -1)
        {
            _originalLayer = gameObject.layer;
            SetLayerRecursively(transform, _carriedLayer);
        }
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void Release(Vector3 dropPosition, Quaternion dropRotation)
    {
        transform.SetParent(null);
        transform.position = dropPosition;
        transform.rotation = dropRotation;
        if (_collider != null)
            _collider.enabled = true;
        if (_carriedLayer != -1)
            SetLayerRecursively(transform, _originalLayer);
        _rb.isKinematic = false;
    }
    private static void SetLayerRecursively(Transform t, int layer)
    {
        t.gameObject.layer = layer;
        foreach (Transform child in t)
            SetLayerRecursively(child, layer);
    }
}