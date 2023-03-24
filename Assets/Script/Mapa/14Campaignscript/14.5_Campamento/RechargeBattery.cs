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

    PlayerHere player;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
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
        if (Input.GetKeyDown(KeyCode.Z) && player.playerImHere)
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
