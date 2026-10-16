using System;
using UnityEngine;

public class PlayerHealth : Health
{
    public event Action OnPlayerDied;

    protected override void Die()
    {
        if (TryGetComponent(out PlayerMovement movement)) movement.enabled = false;
        if (TryGetComponent(out WeaponHandler weapons)) weapons.enabled = false;

        OnPlayerDied?.Invoke(); 
        Debug.Log("El jugador murió");
    }
}
