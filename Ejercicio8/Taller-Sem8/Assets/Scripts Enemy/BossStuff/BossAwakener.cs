using UnityEngine;

public class BossAwakener : MonoBehaviour
{
    public GameObject bossHere;
    private void OnCollisionEnter(Collision collision)
    {
        bossHere.SetActive(true);
    }
}
