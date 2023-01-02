using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest_Work : MonoBehaviour
{
    [SerializeField] TurnosSoldados turno;
    [SerializeField] List<GameObject> lista_A;

    public enum Zona
    {
        zona_A,
        zona_B,
        zona_C,
    }
    public Zona zonaNivel;
    void Start()
    {
        switch (turno.turnos)
        {
            case TurnosSoldados.TurnosTrabajo.AB:
                switch (zonaNivel)
                {
                    case Zona.zona_A:
                        //Zona_A desaparecen
                        //Excavacion_A aparecen
                        break;
                    case Zona.zona_B:
                        //Zona_B desaparecen
                        //Excavacion_B aparecen
                        break;
                    case Zona.zona_C:
                        //Zona_C aparecen
                        //Excavacion_C desaparecen
                        break;
                }
                break;
            case TurnosSoldados.TurnosTrabajo.AC:
                //Zona_A desaparecen
                //Excavacion_A aparecen

                //Zona_B aparecen
                //Excavacion_B desaparecen

                //Zona_C desaparecen
                //Excavacion_C aparecen
                break;
            case TurnosSoldados.TurnosTrabajo.CB:
                //Zona_A aparecen
                //Excavacion_A desaparecen

                //Zona_B desaparecen
                //Excavacion_B aparecen

                //Zona_C desaparecen
                //Excavacion_C aparecen

                break;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void TurnoWork()
    {
        for (int i = 0; i < lista_A.Count; i++)
        {
            lista_A[i].SetActive(true);
        }
    }
}
