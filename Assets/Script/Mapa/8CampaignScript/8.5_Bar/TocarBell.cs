using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarBell : MonoBehaviour
{
    public bool bellSound;

    PlayerHere player;
    [Header("Conducto Info")]
    [SerializeField] GameObject comidaDucto;
    [SerializeField] Animator ductoAnim;
    [Header("Soldado Info")]
    [SerializeField] SoldadoNormal soldadoChef;
    [SerializeField] SoldierLife soldadoChefLife;
    [Header("Ubi Soldado Change")]
    [SerializeField] Transform ubiChefChange;

    public int soundBellCount;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        CallBell();
        ActionBell();
    }
    void CallBell()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                bellSound = true;
                //Deshabilitar para que cuando termine el chef y llegue con la comida poder Volver a tocarla
            }
        }
    }
    void ActionBell()
    {
        if (bellSound && soundBellCount < 1)
        {
            soldadoChef.ubicacionesDirigir[0] = ubiChefChange;
            soundBellCount++;
            ConductoAct();
            //añadir cuenta para que se ejecute una vez
        }
    }
    void ConductoAct()
    {
        //comidaDucto.SetActive(false);
        ductoAnim.SetBool("Abrir", false);
    }
}
