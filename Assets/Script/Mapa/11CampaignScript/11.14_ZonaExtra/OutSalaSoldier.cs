using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OutSalaSoldier : MonoBehaviour
{
    public int indexMod;
    [Header("Soldado Data")]
    [SerializeField] SoldadoNormal soldadoCode;
    [SerializeField] SoldierLife soldadoCodeLife;
    [SerializeField] GameObject triggerSoldadoCode;
    [Header("Time Out Sala")]
    public float timeOutSalaLimit;
    float timeOutSala;
    [Header("Sonido")]
    [SerializeField] EventReference sfxPuerta;

    bool doorInSoldier;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            soldadoCodeLife.gameObject.SetActive(false);
            triggerSoldadoCode.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doorInSoldier)
        {
            SoldierOutScene();
        }
        else
        {
            timeOutSala = 0;
        }
    }
    void SoldierOutScene()
    {
        //NOTA: Lo de que para que el soldado se pire tenga que estar en falso creo que podría ser conflictivo; debido a que si se da el caso de que alguien llama a todos este no se ira nunca y quedara dando vueltas por la zona.
        //Por otro lado, queda el modificar el funcinamiento de la llamada haciendo lo a lo Metal Gear o simplemente quitando esa condicion.
        //ademas no me parece mala idea que se pira sabiendo que tiene un paquete importante entre manos;
        if(soldadoCodeLife.vida > 0)
        {
            //el maxtiempo se establece como el tiempo de espera para irte
            soldadoCode.maxTiempoUbi = timeOutSalaLimit;
            timeOutSala += Time.deltaTime;
            if(timeOutSala >= timeOutSalaLimit)
            {
                AudioManager.instancia.PlayOneShot(sfxPuerta);
                soldadoCodeLife.gameObject.SetActive(false);
                triggerSoldadoCode.SetActive(false);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) doorInSoldier = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) doorInSoldier = false;
    }

}
