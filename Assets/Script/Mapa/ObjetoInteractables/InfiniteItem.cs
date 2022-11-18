using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteItem : MonoBehaviour
{
    [SerializeField] SaveButton itemButton;
    public int indexButton;
    SpawnItemIcon iconItemSpawn;

    PlayerHere player;
    void Start()
    {
        iconItemSpawn = GetComponent<SpawnItemIcon>();
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            TakeItemAgain();
        }
    }
    void TakeItemAgain()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SaveScene.instancia.listaItemsNivelGuardar[indexButton].vecesUsadoObjeto = 0;
            itemButton.HabilitarUsos();
            if(SaveScene.instancia.listaItemsNivelGuardar[indexButton].vecesUsadoObjeto >= 1)
            {
                iconItemSpawn.SpawnIcon();
            }
        }
    }
}
