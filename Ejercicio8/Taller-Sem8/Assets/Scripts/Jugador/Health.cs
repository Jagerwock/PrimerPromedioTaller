using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 100f;

    public float CurrentHealth { get; protected set; }
    public float MaxHealth => maxHealth;
    public bool IsDead { get; private set; }

    public event Action<float, float> OnHealthChanged;

    protected virtual void Awake()
    {
        CurrentHealth = maxHealth;
    }

    protected virtual void Start()
    {
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }

    public virtual void TakeDamage(float amount)
    {
        if (IsDead) return;

        CurrentHealth = Mathf.Max(0f, CurrentHealth - amount);
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0f)
        {
            IsDead = true;
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (IsDead) return;
        CurrentHealth = Mathf.Min(maxHealth, CurrentHealth + amount);
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
