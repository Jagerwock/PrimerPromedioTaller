using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneA; //dascene 1unumm
    [SerializeField] private string sceneB; //dascene 2dossum
    [SerializeField] private string sceneC; //dascene 3trii!!! opd 3?? hl 3?? are u frr????

    public void LoaderAlpha()
    {

        if (sceneA != null)
        {
            SceneManager.LoadScene(sceneA);
        }
        else
        {
            Debug.Log($"erm pls fix!! {sceneA} is brokerino");
        } 
    }

    public void LoaderBetta()
    {
        if (sceneB != null)
        {
            SceneManager.LoadScene(sceneB);
        }
        else
        {
            Debug.Log("erm pls fix!! scene b is no work! PLS Load Value");
        }

    }

    public void LoaderCatto()
    {

        if (sceneC != null)
        {
            SceneManager.LoadScene(sceneC);
        }
        else
        {
            Debug.Log("erm pls fix!! Gatos necesitan un valor asignado para correr variable. Tal vez cargaste la funktion incorrecta?? :u");
        //mad tyeping skillzz. never maid a spekllin mistaek or tiepo- xXYsmaGamerXx
        // ;-;
        }


    }
}
