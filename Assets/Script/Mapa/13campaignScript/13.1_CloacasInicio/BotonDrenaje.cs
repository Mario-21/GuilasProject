using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDrenaje : MonoBehaviour
{
    public int indexMod;
    [Header("Agua Data")]
    [SerializeField] Transform water;
    [SerializeField] WaterData alturaMax;
    [Header("Sprite rejillas")]
    [SerializeField] Sprite rejillaOpen;
    [SerializeField] Sprite rejillaClose;
    [SerializeField] List<SpriteRenderer> rejillas;
    [Header("Valvulas Data")]
    [SerializeField] List<Valvula> valvulas;

    //Añadir el habilitar la valvula 
    //Pero solo si se ha dado previamente a la palanca de mantenimiento de su respectiva zona
    //ademas de 
    bool drenar;
    PlayerHere player;

    void Start()
    {
        drenar = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;

        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = drenar;

        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                drenar = !drenar;
            }
        }
        Drenaje();
    }
    void Drenaje()
    {
        //Rejilla Abierta
        if (drenar)
        {
            water.position = alturaMax.alturaMin.position;
            BloquearValvulas();
            foreach(SpriteRenderer rejilla in rejillas)
            {
                rejilla.sprite = rejillaOpen;
            }
        }
        //Rejilla Cerrada
        else
        {
            foreach (SpriteRenderer rejilla in rejillas)
            {
                rejilla.sprite = rejillaClose;
            }
        }
    }
    void BloquearValvulas()
    {
        for (int e = 0; e < valvulas.Count; e++)
        {
            valvulas[e].valvulaOn = false;
        }
    }
}
