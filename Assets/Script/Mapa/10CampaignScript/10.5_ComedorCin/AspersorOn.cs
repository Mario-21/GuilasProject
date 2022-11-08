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

    void Start()
    {
        
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
            luzAspersor.color = Color.green;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            if(SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida > 0)
            {
                chef.enabled = true;
            }
            this.enabled = false;
            //Destroy(humo);
        }
    }
}
