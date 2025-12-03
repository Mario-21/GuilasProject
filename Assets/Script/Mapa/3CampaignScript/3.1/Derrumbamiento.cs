using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class Derrumbamiento : MonoBehaviour
{
    [Header("Modificacion")]
    public int indexMod;
    //level 3.2 Poner la lista de modificaciones

    [Header("Next Scene")]
    public int nextLevel;
    public int checkpoint;
    [Tooltip("SpawnFuturos es el objeto que hace aparecer los trigger para los spawn en la siguiente escena")]
    public GameObject spawnsFuturos;

    [Header("Player Mov Stop")]
    [SerializeField] BloquearMovimientoPlayer player;
    [SerializeField] VidaPlayer vidaPlayer;

    [Header("Soldier Inactive")]
    public List<SoldadoNormal> listaSoldadosCopia;

    EventInstance rumbling;

    public float tiempoLimiteRumbling;
    public float tiempoRumbling;

    bool timerRumblingOn;
    int numEjecucionesRumbling;
    private void Start()
    {
       rumbling = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.rumbling);
    }

    private void Update()
    {
        //Si entra en activación el Rumbling
        if (timerRumblingOn)
        {
            /*Comenzara una cuenta. Esta cuenta sirve para dar un poco de tiempo a que termine de caerse el último elemento que desemboca el Rumbling*/
            if(tiempoRumbling >= tiempoLimiteRumbling)
            {
                /*Se debe comprobar si el Player esta vivo, para evitar que a la hora de entrar a la siguiente escena, el Rumbling, apararezca muerto, porque si se
                 dan esas condiciones lo que desemboca es que el Player se quede bloqueado, haciendo que la única solución sea reiniciar el nivel*/
                if(vidaPlayer.vidaActual > 0)
                {
                    spawnsFuturos.SetActive(true);
                    /*Una vez comprobado si el Player se encuentra vivo, realizará el Rumbling*/
                    if(numEjecucionesRumbling < 1)
                    {
                        Rumbling();
                        numEjecucionesRumbling++;
                    }
                }
            }
            else
            {
                tiempoRumbling += Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer")) 
        {
            timerRumblingOn = true;
            Destroy(collision.gameObject);
            //se sigue reproduciendo aun cambiando de escena, hacerlo una instancia
            rumbling.start();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("B8"))
        {
            timerRumblingOn = true;
        }
    }
    void Rumbling()
    {

        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

        //Asign the level
        EstructuraNiveles.nivel = nextLevel;
        CheckPointController.numeroCheckPoint = checkpoint;

        //Comienza el <<Rumbling>>
        AnimationHud.detectar_echar.SetBool("Derrumbar", true);

        //Bloquea los movimientos de los enemigos, para no ser atacado
        foreach (SoldadoNormal soldado in listaSoldadosCopia)
        {

            soldado.enabled = false;
            soldado.GetComponent<Animator>().SetBool("WalkSoldier", false);

        }

        //Bloquea tus movimientos y arma para no aprovechar la situacion
        player.BloquearMovPlayer();
    }
    private void OnDisable()
    {
        rumbling.stop(STOP_MODE.IMMEDIATE);
        rumbling.release();
    }

}
