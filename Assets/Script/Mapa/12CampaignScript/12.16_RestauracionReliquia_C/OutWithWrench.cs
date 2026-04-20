using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutWithWrench : MonoBehaviour
{
    public int indexMod;
    [Header("Escena y Spawn")]
    public int siguienteEscena;
    public int checkpointSpanwScene;
    [Header("Player")]
    [SerializeField] GameObject playerCuerpo;
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;

    ActivarModificador activador;

    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            activador.enabled = false;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OutRejilla();
    }
    void OutRejilla()
    {
        if (activador.modificacion)
        {
            activador.enabled = false;
            //Para que no que los enemigos si te ven, no te ataquen al cambiar de zona
            playerCuerpo.layer = 0;
            //Parar el Movimiento del Player
            bloqPlayer.BloquearMovPlayer();
            //Cambiar Zona
            CheckPointController.numeroCheckPoint = checkpointSpanwScene;
            EstructuraNiveles.nivel = siguienteEscena;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
