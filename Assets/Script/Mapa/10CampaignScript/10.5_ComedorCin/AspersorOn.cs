using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspersorOn : MonoBehaviour
{
    public int indexMod;
    [Header("Aspersor")]
    [SerializeField] SpriteRenderer luzAspersor;

    [Header("Duracion Camara")]
    public float timeChangeCameraLimit;
    float timeChangeCamera;

    //[Header("Humo Cigarro")]
    //[SerializeField] GameObject humo;
    [Header("Chef")]
    public int indexChef;
    [SerializeField] SoldadoNormal chef;
    [Header("End Scene")]
    [Tooltip("Solo ocurrira si el soldado a muerto anteriormente")]
    [SerializeField] UseCin end;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        ActivarAspersor();
    }
    void ActivarAspersor()
    {
        timeChangeCamera += Time.deltaTime;
        if(timeChangeCamera >= timeChangeCameraLimit)
        {
            //Enciende el aspersor
            luzAspersor.color = Color.green;

            //Si continua vivo la escena se ejecutara como normalmente lo hace
            if(SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida > 0)
            {
                AnimationHud.detectar_echar.SetBool("Transicion", true);
                Debug.Log("Aspersor chef");
                chef.enabled = true;
            }
            // Si el enemigo ha muerto previamente solo aparecera esta escena
            else
            {
                Debug.Log("Aspersor end");
                end.UseCinematic();
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }

            this.enabled = false;
            //Destroy(humo);
        }
    }

}
