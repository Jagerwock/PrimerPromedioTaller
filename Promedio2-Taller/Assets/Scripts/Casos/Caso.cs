using UnityEngine;

public class Caso : MonoBehaviour
{
    public enum Etapa
    {
        PorRecibir,
        EnMano,
        EnMesa,
        Revisada,
        PorSellar,
        Sellada,
        Terminado
    }

    [SerializeField] private Transform caja;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private GameObject linterna;
    [SerializeField] private GameObject luzUV;

    [SerializeField] private GameObject avisoActual;
    [SerializeField] private GameObject llevarAInspeccion;
    [SerializeField] private GameObject revisarConUV;
    [SerializeField] private GameObject hallazgoUV;
    [SerializeField] private GameObject aprobadoPorSellar;
    [SerializeField] private GameObject rechazadoPorSellar;
    [SerializeField] private GameObject cajaSellada;
    [SerializeField] private GameObject casoCorrecto;
    [SerializeField] private GameObject casoIncorrecto;

    private bool aprobada;

    public Etapa Actual { get; private set; }

    public void RecibirCaja()
    {
        MoverCaja(holdPoint);
        caja.gameObject.SetActive(true);
        Actual = Etapa.EnMano;
        MostrarAviso(llevarAInspeccion);
    }

    public void ColocarLinterna()
    {
        caja.gameObject.SetActive(false);
        linterna.SetActive(true);
        Actual = Etapa.EnMesa;
        MostrarAviso(revisarConUV);
    }

    public void ProbarUV()
    {
        luzUV.SetActive(true);
        Actual = Etapa.Revisada;
        MostrarAviso(hallazgoUV);
    }

    public void Decidir(bool aprobar)
    {
        aprobada = aprobar;
        luzUV.SetActive(false);
        linterna.SetActive(false);
        caja.gameObject.SetActive(true);
        Actual = Etapa.PorSellar;
        MostrarAviso(aprobar ? aprobadoPorSellar : rechazadoPorSellar);
    }

    public void SellarCaja()
    {
        Actual = Etapa.Sellada;
        MostrarAviso(cajaSellada);
    }

    public void DespacharCaja(Transform punto)
    {
        MoverCaja(punto);
        Actual = Etapa.Terminado;
        MostrarAviso(aprobada ? casoIncorrecto : casoCorrecto);
    }

    private void MostrarAviso(GameObject aviso)
    {
        avisoActual.SetActive(false);
        aviso.SetActive(true);
        avisoActual = aviso;
    }

    private void MoverCaja(Transform punto)
    {
        caja.SetParent(punto, false);
        caja.localPosition = Vector3.zero;
        caja.localRotation = Quaternion.identity;
    }
}
