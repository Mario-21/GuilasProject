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
    public Aparecer_DesAp_Obj itemCin;
    [SerializeField] SpriteRenderer botonLavadora;
    [Header("Completar Nivel")]
    [SerializeField] GameObject completarNivel;
    [Header("Diálogo")]
    [SerializeField] GameObject angry;
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
                if(timeBetweenScene >= 2)
                {
                    itemCin.Appear();
                    itemCin.DesAppear();
                    botonLavadora.color = Color.green;
                    AnimationHud.detectar_echar.SetBool("Transicion", false);
                    laundryCin = LaundryScene.Third;
                    timeBetweenScene = 0;
                }
                break;
            case LaundryScene.Third:
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= 3 && contador < 1)
                {
                    Instantiate(globoEnfado, spawnGlobo.transform.position, Quaternion.identity);
                    angry.SetActive(true);
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
