using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSoldier : MonoBehaviour
{
    public int indexMod;
    PlayerHere player;
    [SerializeField] SoldierLife soldadoVida;
    bool soldadoInside;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PushEnemy()
    {
        if (player.playerImHere)
        {
            if(soldadoVida.vida > 0 && soldadoInside)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    //Recarga la escena emitiendo un sonido
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                }
            }
        }
    }
}
