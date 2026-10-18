using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int deathtimer=5;
    [SerializeField] private int currentTimer = 0;
    [SerializeField] private Vector3 Velocity;

    private void Update()
    {
        transform.position += Velocity * Time.deltaTime;
    }
}