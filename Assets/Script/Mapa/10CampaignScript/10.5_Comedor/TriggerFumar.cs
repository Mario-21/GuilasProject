using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFumar : MonoBehaviour
{

    [Header("Player Mask")]
    [SerializeField] PutGasMask colocarCigarro;
    [SerializeField] PutGasMask encenderCigarro;
    [SerializeField] BloquearMovimientoPlayer playerBloq;

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
        else if (chefLife.vida <= 0)
        {
            ConditionsCinematicFumarNoEnemy();
        }

    }
    void ConditionsCinematicFumar()
    {
        //Tienes que entrar en la sala ya fumando 
        if(colocarCigarro.putMask && encenderCigarro.putMask && fumarArea)
        {
            fumarCin.UseCinematic();
            ExtraVariable.extras.comedorScene = ExtraVariable.CinematicComedor105.Aspersor;
        }
        //Si entras a la sala solo con el cigarro sin encender, te echan 
        else if (colocarCigarro.putMask && !encenderCigarro.putMask && fumarArea)
        {
            //bloquear Movimiento y bloquaer menu
            playerBloq.BloquearMovPlayer();
            sacarFumador.Secuence();
        }
    }
    void ConditionsCinematicFumarNoEnemy()
    {
        //Tienes que entrar en la sala ya fumando 
        if (colocarCigarro.putMask && encenderCigarro.putMask && fumarArea)
        {
            fumarCin.UseCinematic();
            ExtraVariable.extras.comedorScene = ExtraVariable.CinematicComedor105.Aspersor;
        }
        Debug.Log("Garma");


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
