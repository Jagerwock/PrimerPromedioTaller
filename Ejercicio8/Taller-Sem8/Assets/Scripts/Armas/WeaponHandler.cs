using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private int currentIndex;

    private void Start()
    {
        EquipWeapon(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipWeapon(2);

        if (Input.GetButton("Fire1") && weapons.Length > 0)
            weapons[currentIndex].TryShoot();
    }

    private void EquipWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length) return;

        currentIndex = index;
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].gameObject.SetActive(i == currentIndex);
    }
}
