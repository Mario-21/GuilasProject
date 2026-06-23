using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDataPlayer : MonoBehaviour
{
    public static ListDataPlayer listDataPlayer;

    [Header("Vida Jugador")]
    public float vidaPlayerNow;
    [Header("Munición Jugador")]
    public int ammoPlayerNow;
    public int ammoPlayerStartScene;
    int ammoPlayerInicial;
    [Header("Orientacion Jugador")]
    public int orientacionPlayer;
    [Header("Información Reliquia en Nivel")]
    public bool reliquiaObtenida;
    //Nota: AmmoPlayerNow no debe destruirse hasta llegar al final.
    private void Awake()
    {
        if (ListDataPlayer.listDataPlayer == null)
        {
            ListDataPlayer.listDataPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //Esto sirve para que cuando resetees el nivel, detecte, si inicialmente la reliquia había sido obtenido con anterioridad o no
        //Si el número de reliquia es inferior a 0, significa que no hay reliquia en el nivel
        if(ListaReliquias.instancia.numReliquiaNivel >= 0 )GameDataNoDestroy.instance.gameData.reliquiasCollected.TryGetValue(ListaReliquias.instancia.listaReliquiasTotal[ListaReliquias.instancia.numReliquiaNivel].idReliquia, out reliquiaObtenida);
        ammoPlayerNow = GameDataNoDestroy.instance.gameData.ammoActual;
        ammoPlayerInicial = GameDataNoDestroy.instance.gameData.ammoActual;
    }
    public void ResetearDataPlayer()
    {
        ammoPlayerNow = ammoPlayerInicial;
        vidaPlayerNow = 100;
    }

}
