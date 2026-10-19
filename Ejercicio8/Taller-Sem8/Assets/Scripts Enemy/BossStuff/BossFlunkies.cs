using System.Collections.Generic;
using UnityEngine;

public class BossFlunkies : MonoBehaviour
{
    public List<GameObject> bossAds = new List<GameObject>();

    
    private void Awake()
    {
        for (int i = 0; i < bossAds.Count; i++)
        {
            GameObject clone = Instantiate(bossAds[i], transform.position - transform.forward * (i * 6f), transform.rotation);
        }
    }

}
