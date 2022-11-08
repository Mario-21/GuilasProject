using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFumar : MonoBehaviour
{

    [Header("Player Mask")]
    [SerializeField] PutGasMask colocarCigarro;
    [SerializeField] PutGasMask encenderCigarro;

    [Header("Cinematic Fumar")]
    public int indexMod;
    public UseCin fumarCin;

    [Header("Detectar")]
    [SerializeField] Detectar_y_Echar sacarFumador;

    [Header("Chef")]
    [SerializeField] SoldierLife chefLife;
    [SerializeField] SoldadoNormal chef;

    bool fumarArea;
    void Start()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Si el chef vive y no esta en modo ataque puede ocurrir la cinematica
        if(chefLife.vida > 0 && !chef.berserker)
        {
            ConditionsCinematicFumar();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void ConditionsCinematicFumar()
    {
        //Tienes que entrar en la sala ya fumando 
        if(colocarCigarro.putMask && encenderCigarro.putMask && fumarArea)
        {
            GoCinematic();
        }
        //Si entras a la sala solo con el cigarro sin encender
        else if (colocarCigarro.putMask && !encenderCigarro.putMask && fumarArea)
        {
            sacarFumador.Secuence();
        }
    }
    void GoCinematic()
    {
        fumarCin.UseCinematic();
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fumarArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fumarArea = false;
        }
    }
}
