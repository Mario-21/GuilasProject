using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identificar_Piso : MonoBehaviour
{
    public int definicion_Piso;
    [SerializeField] Elevator_Automatic_Asig asignacionAutoElev;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (definicion_Piso)
            {
                case 0:
                    asignacionAutoElev.piso_Actual = Elevator_Automatic_Asig.Pisos_Ascensor.Piso_0;
                    break;
                case 1:
                    asignacionAutoElev.piso_Actual = Elevator_Automatic_Asig.Pisos_Ascensor.Piso_1;
                    break;
                case 2:
                    asignacionAutoElev.piso_Actual = Elevator_Automatic_Asig.Pisos_Ascensor.Piso_2;
                    break;
                case 3:
                    asignacionAutoElev.piso_Actual = Elevator_Automatic_Asig.Pisos_Ascensor.Piso_3;
                    break;
            }
        }
    }
}
