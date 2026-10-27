using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PositionReliquiaValvula : MonoBehaviour
{
    public int indexModA;
    public int indexModB;
    [Header("Limite Valvulas")]
    [SerializeField] int limiteUsos;
    [Header("Reliquia Data")]
    [SerializeField] Transform reliquiaPos;
    [SerializeField]ReliquiaValvula valvula_1;
    [SerializeField] Transform valvulaReliquiaPos_1;
    [SerializeField]ReliquiaValvula valvula_2;
    [SerializeField] Transform valvulaReliquiaPos_2;
    [Header("Reliquia Sonido")]
    public EventReference sonidoAction;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModA].modificacion)
        {
            reliquiaPos.position = valvulaReliquiaPos_1.position;
            this.enabled = false;
        }
        else if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModB].modificacion)
        {
            reliquiaPos.position = valvulaReliquiaPos_2.position;
            this.enabled = false;
        }
    }
    void Update()
    {
        if(ClotheData.clotheInfo.numCloth >= limiteUsos)
        {
            if (valvula_1.canIncrease)
            {
                reliquiaPos.position = valvulaReliquiaPos_1.position;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModA].modificacion = true;
                AudioManager.instancia.PlayOneShot(sonidoAction);
                this.enabled = false;
            }
            else if (valvula_2.canIncrease)
            {
                reliquiaPos.position = valvulaReliquiaPos_2.position;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModB].modificacion = true;
                AudioManager.instancia.PlayOneShot(sonidoAction);
                this.enabled = false;
            }
        }
        //reliquiaPos.position = ubiAllReliquia[ClotheData.clotheInfo.numCloth].position;
    }
}
