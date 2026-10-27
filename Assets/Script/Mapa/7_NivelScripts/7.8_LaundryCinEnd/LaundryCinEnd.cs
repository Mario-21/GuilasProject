using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryCinEnd : MonoBehaviour
{
    float timeBetweenScene;
    enum LaundryScene
    {
        First,
        Second,
        Third,
        End
    }
    LaundryScene laundryCin;

    int contador;

    [Header("Lavadora")]
    public GameObject lavadoraOn;
    public GameObject lavadoraOff;
    public Aparecer_DesAp_Obj itemCin;
    [Header("Completar Nivel")]
    [SerializeField] GameObject completarNivel;
    [Header("Diálogo")]
    [SerializeField] GameObject cabeza;
    [SerializeField] GameObject cabezaAngry;
    [SerializeField] GameObject globoEnfado;
    [SerializeField] Transform spawnGlobo;
    void Update()
    {
        LaundryEnd();
    }
    void LaundryEnd()
    {
        switch (laundryCin)
        {
            case LaundryScene.First:
                timeBetweenScene += Time.deltaTime;
                if (timeBetweenScene >= 3)
                {
                    laundryCin = LaundryScene.Second;
                    AnimationHud.detectar_echar.SetBool("Transicion", true);
                    timeBetweenScene = 0;
                }
                break;
            case LaundryScene.Second:

                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 3)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.finishWashingMachine);
                    itemCin.Appear();
                    itemCin.DesAppear();
                    //Cambiar el color de los botones para simular que ha sido apagada
                    lavadoraOn.SetActive(false);
                    lavadoraOff.SetActive(true);
                    AnimationHud.detectar_echar.SetBool("Transicion", false);
                    laundryCin = LaundryScene.Third;
                    timeBetweenScene = 0;
                }
                break;
            case LaundryScene.Third:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 3 && contador < 1)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.angryEnemy);
                    Instantiate(globoEnfado, spawnGlobo.transform.position, Quaternion.identity);
                    //Sustituir por una cabeza cabreada como el truco de la alergia
                    cabeza.SetActive(false);
                    cabezaAngry.SetActive(true);
                    laundryCin = LaundryScene.End;
                    contador++;
                    timeBetweenScene = 0;
                    
                }
                break;
            case LaundryScene.End:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 2)
                {
                    completarNivel.SetActive(true);
                }
                break;
        }
    }
}
