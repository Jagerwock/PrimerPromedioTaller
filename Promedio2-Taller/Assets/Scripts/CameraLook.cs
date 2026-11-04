using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform playerBody;

    [Header("Sensibilidad")]
    [SerializeField] private float mouseSensitivity = 200f;

    [Header("Límites verticales")]
    [SerializeField] private float minVerticalAngle = -80f;
    [SerializeField] private float maxVerticalAngle = 80f;

    private float _verticalRotation = 0f;

    public bool CanLook { get; set; } = true;

    private void Reset()
    {

        if (playerBody == null && transform.parent != null)
            playerBody = transform.parent;
    }

    private void Update()
    {
        if (!CanLook)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, minVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
}