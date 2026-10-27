using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCinematic : MonoBehaviour
{
    public static DataCinematic dataCin;

    public enum CinematicComedor96
    {
        Aspersor,
        Veneno
    }
    public CinematicComedor96 comedorScene;
    private void Awake()
    {
        if(DataCinematic.dataCin == null)
        {
            DataCinematic.dataCin = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
