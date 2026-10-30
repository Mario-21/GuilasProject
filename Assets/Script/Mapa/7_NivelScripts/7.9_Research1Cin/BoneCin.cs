using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCin : MonoBehaviour
{
    [Header("Info Cinematic Bone")]
    [SerializeField] Transform boneSoldier;
    [SerializeField] ParticleSystem boneLlamar;
    public int levelOriginal;
    public string nombreSiguienteEscenaOriginal;
    public int checkpoint;
    enum BoneCinematic
    {
        FirstBone,
        SecondBone,
        End
    }
    BoneCinematic boneCinema;
    float timeBetweenScene;
    void Update()
    {
        BoneC();
    }
    void BoneC()
    {
        switch (boneCinema)
        {
            case BoneCinematic.FirstBone:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 3)
                {
                    //Se gira el soldado
                    boneSoldier.localScale = new Vector3(-1, 1, 1);
                    boneCinema = BoneCinematic.SecondBone;
                    timeBetweenScene = 0;
                }
                break;
            case BoneCinematic.SecondBone:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 1)
                {
                    boneLlamar.Play();
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.detect_CadaverMode);
                    boneCinema = BoneCinematic.End;
                    timeBetweenScene = 0;
                }
                break;
            case BoneCinematic.End:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 1)
                {
                    CheckPointController.numeroCheckPoint = checkpoint;
                    EstructuraNiveles.nivel = levelOriginal;
                    EstructuraNiveles.nombreNivel = nombreSiguienteEscenaOriginal;
                    AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                }
                break;
        }
    }
}
