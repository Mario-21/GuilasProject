using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearAscensor : MonoBehaviour
{
    [Header("Propiedades Engranaje")]
    public float speedGear;
    Transform gearTransform;
    [Header("Propiedades Ascensor")]
    [SerializeField] Transform ascensorPos;
    [SerializeField] List<Transform> listFloors;

    int floorActual;
    int resetConfirmPos;

    private void Awake()
    {
        gearTransform = GetComponent<Transform>();
    }
    void Update()
    {
        GearSpin();
        if (resetConfirmPos < 1)
        {
            ConfirmPosElevator();
        }
    }
    void GearSpin()
    {
        if(ascensorPos.transform.position != listFloors[floorActual].transform.position)
        {
            gearTransform.Rotate(0f,0f, speedGear);
            resetConfirmPos = 0;
        }
    }
    void ConfirmPosElevator()
    {
        for (int i = 0; i < listFloors.Count; i++)
        {
            //Si uno coincide el bucle se acaba 
            if(ascensorPos.transform.position == listFloors[i].transform.position)
            {
                floorActual = i;
                resetConfirmPos++;
                Debug.Log("Todo el condumio " + i);
                break;
            }
        }
    }
}
