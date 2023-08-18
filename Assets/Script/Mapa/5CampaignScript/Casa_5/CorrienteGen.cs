using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHere))]
[RequireComponent(typeof(PressActionSounds))]
public class CorrienteGen : MonoBehaviour
{
    public int indexMod;
    [SerializeField] EncenderTaladro drill;
    [SerializeField] SpriteRenderer boton;

    PlayerHere player;
    PressActionSounds actionSound;
    bool corriente;

    private void Awake()
    {
        player = GetComponent<PlayerHere>();
        actionSound = GetComponent<PressActionSounds>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            corriente = true;
            actionSound.action = true;
        }
        else
        {
            corriente = false;
            actionSound.action = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DarCorriente();
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                corriente = !corriente;
            }
        }
    }
    void DarCorriente()
    {
        if (corriente)
        {
            drill.enabled = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            boton.color = Color.green;
        }
        else
        {
            drill.enabled = false;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            boton.color = Color.red;
        }
    }
}
