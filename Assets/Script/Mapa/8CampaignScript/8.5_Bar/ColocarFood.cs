using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ColocarFood : MonoBehaviour
{
    TimeAndAction timeAction;
    [Header("Food")]
    [SerializeField] FinishCook endCooking;
    [SerializeField] GameObject comidaChef;
    [SerializeField] GameObject comidaColocada;
    int foodCount;
    [Header("Ducto")]
    [SerializeField] Animator ductoAnimator;
    public bool ductoAction;
    float timeDucto;
    [Header("Chef Info")]
    [SerializeField] SoldadoNormal chef;
    [SerializeField] SoldierLife chefLife;
    [SerializeField] Transform originalPos;
    [Header("SFX Comida")]
    [SerializeField] EventReference foodColocar;
    void Start()
    {
        timeAction = GetComponent<TimeAndAction>();
    }

    // Update is called once per frame
    void Update()
    {
        //Para que comience la accion debe acabar de cocinar
        if (endCooking.plateFinish && chefLife.vida > 0)
        {
            timeAction.TimeActionOn();
            //Primero coloca la comida una vez
            ColocarComida();
            //Al terminar de colocar la comida el ducto se cierra, tras eso pasado un tiempo se vuelve abrir
            CerrarDucto();
        }
    }
    
    void ColocarComida()
    {
        //Solo una vez para que no entre en conflicto con CerrarDucto() y nunca pueda desaparecer la comida.
        if (timeAction.onTime && foodCount < 1)
        {
            AudioManager.instancia.PlayOneShot(foodColocar);
            comidaChef.SetActive(false);
            comidaColocada.SetActive(true);
            foodCount++;
        }
        else if (!timeAction.onTime)
        {
            foodCount = 0;
        }
    }
    void CerrarDucto()
    {
        if (timeAction.action)
        {
            timeDucto += Time.deltaTime;
            //Se cierra el ducto
            ductoAnimator.SetBool("Cerrar", true);
            if(timeDucto >= 2)
            {
                //Desaparece la comida, porque es trasladada
                comidaColocada.SetActive(false);
                //Pasado un tiempo el ducto se vuelve abrir 
                ductoAnimator.SetBool("Cerrar", false);
                //Para poder accionar el segundo ducto para que haga su accion de manera independiente
                ductoAction = true;
                //Reinicia el tiempo
                timeDucto = 0;
                //Vuelve a la posicion original
                chef.ubicacionesDirigir[0] = originalPos;
                //Acaba la accion de ColocarFood
                endCooking.plateFinish = false;
                //Resetea el volver hacer una accion
                timeAction.timeAction = 0;
                timeAction.action = false;

            }
        }
    }
}
