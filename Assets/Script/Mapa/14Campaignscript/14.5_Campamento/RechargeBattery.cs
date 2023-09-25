using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeBattery : MonoBehaviour
{
    public int indexMod;
    [Header("Battery No Energy")]
    [SerializeField] SpriteRenderer bNoEnergy;
    [Header("Battery Energy")]
    [SerializeField] SpriteRenderer bEnergy;
    [Header("Cable Battery")]
    [SerializeField] GameObject cable;


    ActivarModificador activador; 
    private void Awake()
    {
        activador = GetComponent<ActivarModificador>();
    }

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            Recharge();
        }
    }
    private void Update()
    {
        if (activador.modificacion)
        {
            Recharge();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
    void Recharge()
    {
        bNoEnergy.color = Color.yellow;
        bEnergy.color = Color.red;
        cable.SetActive(true);

        this.enabled = false;
    }

}
