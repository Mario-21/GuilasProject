using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    [Header("Variables Nivel")]
    public List<bool> variablesStartLevel;
    [Header("Items Nivel")]
    public List<ListaTodosObjetos> itemsStartLevel;
    [Header("Reliquias Nivel")]
    public List<bool> reliquiaStartLevel;
    [Header("Enemies Nivel")]
    public List<ListaStatusSoldierScenes> vidaSoldados;
    [Header("Terminales Nivel")]
    public List<bool> terminalesStartLevel;
    [Header("Municion Nivel")]
    public List<bool> ammoStartLevel;
    [Header("Ui Items Nivel")]
    public List<bool> uiItemsStartLevel;
    [Header("Inventory Position")]
    public int inventoryPosStart;
    [Header("Municiones Player")]
    [SerializeField] ArmaController mainWeaponPlayer;
    public int municionStartLevel;
    bool establecerAmmoInicial;
    [Header("Vida Player")]
    public float vidaPlayerStartLevel;
    [Header("Note Nivel")]
    public int noteStart;

    private void Awake()
    {
        mainWeaponPlayer = FindObjectOfType<ArmaController>();
    }
    void Start()
    {
        vidaPlayerStartLevel = ListDataPlayer.listDataPlayer.vidaPlayerNow;
        //Establecer notes iniciales
        noteStart = ObjectivesLevels.instanceObjectivesLevel.indexLine;

        //Establecer Posicion inicial de inventario
        inventoryPosStart = InventoryManager.instanciaInventory.indexInventoryPosition;

        //Coloca la municion

        //Variables Level
        for(int e = 0; e < variablesStartLevel.Count; e++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[e].modificacion)
            {
                variablesStartLevel[e] = true;
            }
        }
        //Items Level
        for (int w = 0; w < itemsStartLevel.Count; w++)
        {
            if (SaveScene.instancia.listaItemsNivelGuardar[w].objetoObtenido)
            {
                itemsStartLevel[w].objetoObtenido = true;
                itemsStartLevel[w].vecesUsadoObjeto = SaveScene.instancia.listaItemsNivelGuardar[w].vecesUsadoObjeto;
                itemsStartLevel[w].ubiPosButton = SaveScene.instancia.listaItemsNivelGuardar[w].ubiPosButton;
            }
        }
        //Reliquias Level
        for(int i = 0; i < reliquiaStartLevel.Count; i++)
        {
            if (ListaReliquias.instancia.listaReliquiasTotal[i].reliquiaObtenida)
            {
                reliquiaStartLevel[i] = true;
            }
        }
        //Soldados Level
        for(int h = 0; h < vidaSoldados.Count; h++)
        {
            vidaSoldados[h].statusVida = SoldierActiveInScene.instancia.soldiersStatus[h].statusVida;
            vidaSoldados[h].berserkerStatus = SoldierActiveInScene.instancia.soldiersStatus[h].berserkerStatus;
        }
        //Terminales Level
        if(TotalTerminales.terminalesTotales != null)
        {
            for (int k = 0; k < terminalesStartLevel.Count; k++)
            {
                if (TotalTerminales.terminalesTotales.terminalesActivos[k])
                {
                    terminalesStartLevel[k] = true;
                }
            }
        }
        //Ammo Level
        if(AmmoRecoveryList.ammoFromLevel != null)
        {
            for(int t = 0; t < ammoStartLevel.Count; t++)
            {
                if (AmmoRecoveryList.ammoFromLevel.ammo[t])
                {
                    ammoStartLevel[t] = true;
                }
            }
        }
        //UI Level
        if(ListaItemsUI.listaItemsUI != null)
        {
            for (int h = 0; h < uiItemsStartLevel.Count; h++)
            {
                if (ListaItemsUI.listaItemsUI.listaAllItemUI[h].itemUICatch)
                {
                    uiItemsStartLevel[h] = true;
                }
            }
        }
    }
    private void Update()
    {
        if (!establecerAmmoInicial)
        {
            ListDataPlayer.listDataPlayer.ammoPlayerStartScene = ListDataPlayer.listDataPlayer.ammoPlayerNow;
            establecerAmmoInicial = true;
        }
    }
    public void ResetearVariablesZona()
    {
        //Si son diferentes establece la variable a como estaba al inicio del nivel
        for (int w = 0; w < variablesStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if(StatusGameobjectsVariables.statusGameobject.modificacion[w].modificacion != variablesStartLevel[w])
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[w].modificacion = variablesStartLevel[w];
            }
        }
    }
    public void ResetearItemsZona()
    {
        for (int w = 0; w < itemsStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (SaveScene.instancia.listaItemsNivelGuardar[w].objetoObtenido != itemsStartLevel[w].objetoObtenido)
            {
                SaveScene.instancia.listaItemsNivelGuardar[w].objetoObtenido = itemsStartLevel[w].objetoObtenido;
            }
            if(SaveScene.instancia.listaItemsNivelGuardar[w].vecesUsadoObjeto != itemsStartLevel[w].vecesUsadoObjeto)
            {
                SaveScene.instancia.listaItemsNivelGuardar[w].vecesUsadoObjeto = itemsStartLevel[w].vecesUsadoObjeto;
            }
        }
    }
    public void ResetarReliquiasZona()
    {
        for (int w = 0; w < itemsStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (ListaReliquias.instancia.listaReliquiasTotal[w].reliquiaObtenida != reliquiaStartLevel[w])
            {
                ListaReliquias.instancia.listaReliquiasTotal[w].reliquiaObtenida = reliquiaStartLevel[w];
                if (GameDataNoDestroy.instance.gameData.reliquiasCollected.ContainsKey(ListaReliquias.instancia.listaReliquiasTotal[w].idReliquia))
                {
                    GameDataNoDestroy.instance.gameData.reliquiasCollected.Remove(ListaReliquias.instancia.listaReliquiasTotal[w].idReliquia);
                    //GameDataNoDestroy.instance.gameData.nivelesComplete.Add(idReliquia, reliquiaRecogida);
                }
                GameDataNoDestroy.instance.gameData.reliquiasCollected.Add(ListaReliquias.instancia.listaReliquiasTotal[w].idReliquia, reliquiaStartLevel[w]);
            }
        }
    }
    public void ResetearSoldado()
    {
        for (int w = 0; w < vidaSoldados.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            //Deben de establecer tambien cuando es modificado el modeSoldier, dado que si mueres sin hacerles daño hace que su mode no cambie
            if (SoldierActiveInScene.instancia.soldiersStatus[w].statusVida != vidaSoldados[w].statusVida || SoldierActiveInScene.instancia.soldiersStatus[w].berserkerStatus != vidaSoldados[w].berserkerStatus)
            {
                SoldierActiveInScene.instancia.soldiersStatus[w].statusVida = vidaSoldados[w].statusVida;
                SoldierActiveInScene.instancia.soldiersStatus[w].berserkerStatus = vidaSoldados[w].berserkerStatus;
            }
        }
    }
    public void ResetearTerminales()
    {
        for (int w = 0; w < terminalesStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (TotalTerminales.terminalesTotales.terminalesActivos[w] != terminalesStartLevel[w])
            {
                TotalTerminales.terminalesTotales.terminalesActivos[w] = terminalesStartLevel[w];
            }
        }
    }
    public void ResetearMunicionPlayer()
    {
        //La municion de ahora pasa a ser la munición con la que entraste para resetear el ultimo checkpoint
        ListDataPlayer.listDataPlayer.ammoPlayerNow = ListDataPlayer.listDataPlayer.ammoPlayerStartScene;
    }
    public void ResetearInventoryPos()
    {
        InventoryManager.instanciaInventory.indexInventoryPosition = inventoryPosStart;
    }
    public void ResetearAmmo()
    {
        for (int w = 0; w < ammoStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (AmmoRecoveryList.ammoFromLevel.ammo[w] != ammoStartLevel[w])
            {
                AmmoRecoveryList.ammoFromLevel.ammo[w] = ammoStartLevel[w];
            }
        }
    }
    public void ResetearUiItems()
    {
        for (int w = 0; w < uiItemsStartLevel.Count; w++)
        {
            //Si son diferentes, quiere decir que lo acabas de modificar ahora pero has muerto en el proceso, por tanto debe resetearse
            if (ListaItemsUI.listaItemsUI.listaAllItemUI[w].itemUICatch != uiItemsStartLevel[w])
            {
                ListaItemsUI.listaItemsUI.listaAllItemUI[w].itemUICatch = uiItemsStartLevel[w];
            }
        }
    }
    public void ResetearNote()
    {
        ObjectivesLevels.instanceObjectivesLevel.indexLine = noteStart;
    }
    public void ResetearVida()
    {
        ListDataPlayer.listDataPlayer.vidaPlayerNow = vidaPlayerStartLevel;
    }

}
