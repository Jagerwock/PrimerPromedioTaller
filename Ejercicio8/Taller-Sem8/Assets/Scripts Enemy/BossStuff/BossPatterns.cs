using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPatterns : MonoBehaviour
{
    [SerializeField] private int fibo1 = 0;
    [SerializeField] private int fibo2 = 1;    
    [SerializeField] private int maxFibVal = 3;
    [SerializeField] private float cooldown = 10f;
    [SerializeField] private float timer = 0.1f;
    [SerializeField]int lasCalled = 0;
    public GameObject bulletPrefab;
    public BossFlunkies bossFlunkies;

    //jaja pq tendriamos start am iright
    // esto es un chiste
    //por motivos legales btw
    void Update()
    {
        timer += Time.deltaTime;
        if (bulletPrefab != null && timer>cooldown) 
        {
            BossPowerRAMPUP();
            BossRotate();
            timer = 0;
        }

    }

    void BossPowerRAMPUP()
    {
        int myFunnycommentsDiedHere = fibo1+fibo2;

        fibo1 = fibo2;
        fibo2 = myFunnycommentsDiedHere;

        for (int i = 0; i < myFunnycommentsDiedHere; i++)
        {
            Instantiate(bulletPrefab, transform.position, transform.localRotation);
        }

        if (myFunnycommentsDiedHere >= maxFibVal)
        {
            fibo1 = 0;
            fibo2 = 1;
        }


    }

    void BossRotate() 
    {

        switch (lasCalled)
        {
            case 0:
                transform.Rotate(new Vector3(0, 90, 0), Space.World);   
                lasCalled++;
                break; 
            case 1:
                transform.Rotate(new Vector3(0, 90, 0), Space.World);
                Instantiate(bossFlunkies, transform.position - transform.right, transform.rotation);
                lasCalled++;
                break;
            case 2:
                transform.Rotate(new Vector3(0, 90, 0), Space.World);
                lasCalled++;
                break;
            case 3:
                transform.Rotate(new Vector3(0, 90, 0), Space.World);
                Instantiate(bossFlunkies, transform.position - transform.right, transform.rotation);
                lasCalled = 0;
                break;
            default: lasCalled = 0; break;
        }

    }
}
