using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RecoveryRoomCinematic : MonoBehaviour
{
    public int indexMod;
    public int returnScene;
    public int checkpoint;
    /*)
    [Header("Soldado Normal Spawn")]
    //que el soldado normal aparezca a cierta distancia, para que se adapte el soldado, dependiendo del switch muera 
    [SerializeField] Transform soldierNormal;
    [SerializeField] Transform soldierSpawn;*/
    [Header("Duracion entre escenas")]
    public float timeBetweenScene;
    [Header("Scena Cortocircuito")]
    public float timeScene1;
    [SerializeField] SoldadoNormal soldadoCircuito;
    [SerializeField] GameObject pantallaNegro;
    [SerializeField] Animator pantallaNegroAnim;
    [SerializeField] EventReference descargarElec;
    [Header("Scena Pantalla Negro")]
    public float timeScene2;
    [SerializeField] GameObject soldadoCircuitoCuerpo;
    [SerializeField] GameObject soldadoCircuitoCadaver;
    [SerializeField] GameObject soldadoNormal;
    [SerializeField] GameObject soldadoSomnoliento;
    [SerializeField] Transform soldadoNormalUbi;
    [SerializeField] Transform soldadoSomnolientoUbi;
    [Header("Scena Conversacion")]
    public float timeScene3;
    [SerializeField] GameObject globoDialogo;
    [SerializeField] Transform glopoPos;
    int onlyOneGlobo;
    [Header("Scene End")]
    public float timeScene4;
    enum CinematicOrder
    {
        Cortocircuito_1, 
        PantallaNegra_2,
        Conversacion_3,
        End_4
    }
    CinematicOrder cinematic;
    void Start()
    {
        //soldierNormal.position = new Vector3(soldierSpawn.position.x, soldierNormal.position.y, soldierNormal.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        BeginScene();
    }
    void BeginScene()
    {
        switch (cinematic)
        {
            case CinematicOrder.Cortocircuito_1:
                soldadoCircuito.enabled = true;
                timeBetweenScene += Time.deltaTime;
                //Quizas falla, dado que recuerdo que si el tiempo llegaba al momento que deseas que se ejecuten las cosas había cosas que fallaban
                if(timeBetweenScene >= timeScene1)
                {
                    pantallaNegro.SetActive(true);
                    AudioManager.instancia.PlayOneShot(descargarElec);
                    timeBetweenScene = 0;
                    cinematic = CinematicOrder.PantallaNegra_2;
                }
                break;
            case CinematicOrder.PantallaNegra_2:
                timeBetweenScene += Time.deltaTime;
                //Soldado Circuito se intercambia por su cadaver
                soldadoCircuitoCuerpo.SetActive(false);
                soldadoCircuitoCadaver.SetActive(true);
                //Los soldado restarntes se dirigen a donde esta el cadaver
                soldadoNormal.transform.position = soldadoNormalUbi.position;
                soldadoSomnoliento.transform.position = soldadoSomnolientoUbi.position;

                if(timeBetweenScene >= timeScene2)
                {
                    //Activar animacion de la pantalla para poder iniciar la siguiente escena.
                    pantallaNegroAnim.SetBool("Transicion", true);
                    timeBetweenScene = 0;
                    cinematic = CinematicOrder.Conversacion_3;
                }
                break;
            case CinematicOrder.Conversacion_3:
                timeBetweenScene += Time.deltaTime;
                if (timeBetweenScene >= timeScene3)
                {
                    Dialogo();
                    timeBetweenScene = 0;
                    cinematic = CinematicOrder.End_4;
                }
                break;
            case CinematicOrder.End_4:
                timeBetweenScene += Time.deltaTime;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                if (timeBetweenScene >= timeScene4)
                {
                    CheckPointController.numeroCheckPoint = checkpoint;
                    EstructuraNiveles.nivel = returnScene;
                    AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                }
                break;
        }
    }
    void Dialogo()
    {
        if (onlyOneGlobo < 1)
        {
            Instantiate(globoDialogo, glopoPos.position, Quaternion.identity);
            onlyOneGlobo++;
        }
    }
}
