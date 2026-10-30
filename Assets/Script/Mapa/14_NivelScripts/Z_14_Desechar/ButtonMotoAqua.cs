using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(PlayerHere))]
public class ButtonMotoAqua : MonoBehaviour
{
    PlayerHere player;
    BoxCollider2D triggerBox;

    [Header("Escena y Spawn")]
    public int siguienteEscena;
    public string nombreSiguienteEscena;
    public int checkpointSpanwScene;
    [Header("Player")]
    [SerializeField] GameObject playerCuerpo;
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header("Variables")]
    [SerializeField] List<int> listIndex;
    [Header("Button")]
    [SerializeField] SpriteRenderer button;
    [SerializeField] Color colorButtonOff;
    [Header("Sfx Sacar Moto")]
    [SerializeField] EventReference sfx_Moto;

    int variables;

    private void Awake()
    {
        triggerBox = GetComponent<BoxCollider2D>();
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        for (int i = 0; i < listIndex.Count; i++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[listIndex[i]].modificacion)
            {
                variables++;
            }
        }
        if(variables >= listIndex.Count)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                ActivateAlarm();
            }
        }
    }
    void ActivateAlarm()
    {
        AudioManager.instancia.PlayOneShot(sfx_Moto);
        //Desactivar collider
        triggerBox.enabled = false;
        //Para que no que los enemigos si te ven, no te ataquen al cambiar de zona
        playerCuerpo.layer = 0;
        //Parar el Movimiento del Player
        bloqPlayer.BloquearMovPlayer();
        //Activar Variables
        for (int e = 0; e < listIndex.Count; e++)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[listIndex[e]].modificacion = true;
        }
        //Feedback Button
        button.color = colorButtonOff;
        //Cambiar Zona
        CheckPointController.numeroCheckPoint = checkpointSpanwScene;
        EstructuraNiveles.nivel = siguienteEscena;
        EstructuraNiveles.nombreNivel = nombreSiguienteEscena;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");

    }
}
