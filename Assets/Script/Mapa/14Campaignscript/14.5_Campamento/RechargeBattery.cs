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

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            Recharge();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Recharge();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
    void Recharge()
    {
        bNoEnergy.color = Color.yellow;
        bEnergy.color = Color.red;

        this.enabled = false;
    }

}
