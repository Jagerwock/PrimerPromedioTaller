using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserWeapon : Weapon
{
    [Header("Láser")]
    [SerializeField] private float range = 30f;
    [SerializeField] private float beamDuration = 0.05f;
    [SerializeField] private LayerMask hitMask = ~0; 

    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
    }

    protected override void Fire()
    {
        Vector3 start = firePoint.position;
        Vector3 end = start + firePoint.forward * range;

        if (Physics.Raycast(start, firePoint.forward, out RaycastHit hit, range, hitMask, QueryTriggerInteraction.Ignore))
        {
            end = hit.point;
            Health health = hit.collider.GetComponentInParent<Health>();
            if (health != null) health.TakeDamage(damage);
        }

        StopAllCoroutines();
        StartCoroutine(ShowBeam(start, end));
    }

    private IEnumerator ShowBeam(Vector3 start, Vector3 end)
    {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        line.enabled = true;
        yield return new WaitForSeconds(beamDuration);
        line.enabled = false;
    }
}
