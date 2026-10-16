using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Max(health, 0);

        Debug.Log("Player Health: " + health);

        if (health <= 0)
            Debug.Log("Player defeated!");
    }
}
