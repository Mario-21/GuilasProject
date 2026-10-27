using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerObjetoResguardado : MonoBehaviour
{
    [Header("Condiciones Habilitar Recoger Objeto")]
    public int indexModCondition;
    [SerializeField] SoldierLife soldier;
    [SerializeField] SoldadoNormal soldierStatus;
    [Header("Objeto a Habilitar")]
    [SerializeField] CogerObjeto objeto;
    [Header("Soldado Echar Por Robar")]
    [SerializeField] GameObject cambiarArea;
    [SerializeField] GameObject brazoNormal;
    [SerializeField] GameObject brazoAlerta;

    PlayerHere playerHere;
    void Start()
    {
        playerHere = GetComponent<PlayerHere>();
        if (soldier.vida <= 0 || StatusGameobjectsVariables.statusGameobject.modificacion[indexModCondition].modificacion)
        {
            objeto.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CondicionesHabilitarObjeto();
    }
    void CondicionesHabilitarObjeto()
    {
        if (soldier.vida <= 0 || StatusGameobjectsVariables.statusGameobject.modificacion[indexModCondition].modificacion)
        {
            Debug.Log("Ha fallecido o se ha cumplido la variable del " + soldierStatus.gameObject.name);
            objeto.enabled = true;
            this.enabled = false;
        }
        //La condicion de recoger ell objeto que se ve en AlertaPorObjeto() aquí no es necesaria, debido a que cuando yo recoja el objeto ese mismo desaparecerá,
        //haciendo imposible que el soldado te puede llamar la atención por no recoger nada.
        else if(soldier.vida > 0 && !soldierStatus.berserker)
        {
            objeto.enabled = false;
            
            if (playerHere.playerImHere && Input.GetButtonDown("Take"))
            {
                cambiarArea.SetActive(true);
                brazoNormal.SetActive(false);
                brazoAlerta.SetActive(true);
            }
        }
        if (soldierStatus.berserker)
        {
            Debug.Log("Esta en modo berserker, pero puede ser robado el " + soldierStatus.gameObject.name);
            objeto.enabled = true;
        }
    }
}
