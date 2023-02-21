using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desatasco : MonoBehaviour
{
    public int indexMod;
    [Header("Desatascar Data")]
    [SerializeField] BotonDrenaje drenaje;
    [SerializeField] GameObject itemDesatascado;
    [SerializeField] GameObject garbage;
    [Header("Time Desatascar")]
    public float timeDesatascarLimit;
    float timeDesatascar;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer playerBloq;

        
    ActivarModificador activador;
    bool beginDesatacar;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();

        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            Desatascar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion) beginDesatacar = true;
        if (beginDesatacar) TimeDesatacar();
    }
    void Desatascar()
    {
        //Ya puedes usar el drenaje
        drenaje.enabled = true;
        //Sacas el item de la morralla
        itemDesatascado.SetActive(true);
        //Basura que se queda por el suelo
        garbage.SetActive(true);
        //Adios Atasco
        this.gameObject.SetActive(false);
        //Variable Activada
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
    void TimeDesatacar()
    {
        if(timeDesatascar >= timeDesatascarLimit)
        {
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            playerBloq.HabilitarMovPlayer();
            Desatascar();
        }
        else
        {
            timeDesatascar += Time.deltaTime;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            playerBloq.BloquearMovPlayer();
        }
    }

}
