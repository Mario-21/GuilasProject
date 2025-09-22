using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryRoomCinematic : MonoBehaviour
{
    public int indexMod;
    public int returnScene;
    public int checkpoint;
    [Header("Soldado Normal Spawn")]
    //que el soldado normal aparezca a cierta distancia, para que se adapte el soldado, dependiendo del switch muera 
    [SerializeField] Transform soldierNormal;
    [SerializeField] Transform soldierSpawn;
    [Header("Globo Dialogo")]
    [SerializeField] GameObject globoDialogo;
    [SerializeField] Transform glopoPos;
    public float timeBetweenScene;
    public float timeBetweenSceneLimit;
    int onlyOneGlobo;
    enum CinematicOrder
    {
        Start, 
        Middle,
        End
    }
    CinematicOrder cinematic;
    void Start()
    {
        soldierNormal.position = new Vector3(soldierSpawn.position.x, soldierNormal.position.y, soldierNormal.position.z);
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
            case CinematicOrder.Start:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= timeBetweenSceneLimit)
                {
                    cinematic = CinematicOrder.Middle;
                }
                break;
            case CinematicOrder.Middle:
                Dialogo();
                cinematic = CinematicOrder.End;
                break;
            case CinematicOrder.End:
                timeBetweenScene -= Time.deltaTime;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                if (timeBetweenScene <= 0)
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
