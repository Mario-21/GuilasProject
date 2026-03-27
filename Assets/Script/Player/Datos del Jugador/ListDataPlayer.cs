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
    [Header("Orientacion Jugador")]
    public int orientacionPlayer;
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
}
