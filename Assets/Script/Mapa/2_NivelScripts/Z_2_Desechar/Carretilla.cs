using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carretilla : MonoBehaviour
{
    public int indexSoldado;    
    [SerializeField] Transform player;
    [SerializeField] SoldierLife soldadoVida;

    public int vidaActual;
    private void Awake()
    {
        soldadoVida = GetComponentInParent<SoldierLife>();
    }
    void Start()
    {
        vidaActual = SoldierActiveInScene.instancia.soldiersStatus[indexSoldado].statusVida;
    }

    // Update is called once per frame
    void Update()
    {
        AnularParent();
    }
    void AnularParent()
    {
        if (soldadoVida.vida != vidaActual ||
            soldadoVida.GetComponent<SoldadoNormal>().berserker ||
            soldadoVida.GetComponent<SoldadoNormal>().seeCadaverWarning ||
            soldadoVida.vida <= 0) 
        { Debug.Log("Ya no hijo"); transform.parent = null; }
    }
}
