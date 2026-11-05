using UnityEngine;

public class LuzParpadeante : MonoBehaviour
{
    [SerializeField] private Light luz;
    [SerializeField] private float intervalo = 1.5f;

    private float tiempo;

    private void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= intervalo)
        {
            luz.enabled = !luz.enabled;
            tiempo = 0f;
        }
    }
}
