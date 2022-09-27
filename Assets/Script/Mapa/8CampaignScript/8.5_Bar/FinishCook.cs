using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCook : MonoBehaviour
{
    bool cook;
    public bool plateFinish;
    [Header("Time for Cook")]
    public float timeCookLimit;
    float timeCook;
    [SerializeField] TocarBell bell;
    [Header("Plate")]
    [SerializeField] GameObject plate;
    [SerializeField] Transform colocarFood;
    [Header("Chef Info")]
    [SerializeField] SoldadoNormal chefSoldado;
    [SerializeField] SoldierLife chefSoldadoLife;
    void Update()
    {
        //Si esta vivo
        if(chefSoldadoLife.vida > 0) CookChef();
    }
    void CookChef()
    {
        //cuando el tio esta vivo
        if (cook)
        {
            timeCook += Time.deltaTime;
            if(timeCook >= timeCookLimit)
            {
                //Se coloca en falso para que me permita cambiar la posicion
                bell.bellSound = false;
                //El chef se dirige al conducto para dejar la comida
                chefSoldado.ubicacionesDirigir[0] = colocarFood;
                //Tienes el plato en la mano
                plate.SetActive(true);
                //Refencia para poder usar ColocarFood teniendo prevsiamente el plato hecho
                plateFinish = true;
                //Resetear valores de la cocina
                timeCook = 0;
                cook = false;
                // NOTA : No se si poner una barra de progeso o algo que te haga entender que esta apunto de acabar
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cook = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cook = false;
            timeCook = 0;
        }
    }
}
