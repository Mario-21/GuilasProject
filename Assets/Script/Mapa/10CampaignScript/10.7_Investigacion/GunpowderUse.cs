using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GunpowderUse : MonoBehaviour
{
    //Si este index no esta activo significa que no se ha realizado la accion por parte del enemigo
    public int indexMod;
    [Tooltip("Se necesita una accion previa para activarlo")]
    public int indexGunpowder;
    [Header("FeedBack")]
    [SerializeField] GameObject suciedad;
    [Header("Item")]
    [SerializeField] GameObject item;
    [Header("Tiempo Dejar Huellas")]
    public float timeHuellasLimit;
    public float timeHuellas;
    [Header("Huella SFX")]
    [SerializeField] EventReference sfxHuella;

    ActivarModificador activador;
    bool huellas;



    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            item.SetActive(true);
            this.enabled = false;
        }
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexGunpowder].modificacion)
        {
            suciedad.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Saber si la mesa esta sucia
        if (activador.modificacion || StatusGameobjectsVariables.statusGameobject.modificacion[indexGunpowder].modificacion) 
        {
            FingerPrints();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexGunpowder].modificacion = true;
            suciedad.SetActive(true);
        }
    }
    void FingerPrints()
    {
        if (huellas)
        {
            timeHuellas += Time.deltaTime;
            if(timeHuellas >= timeHuellasLimit)
            {
                AudioManager.instancia.PlayOneShot(sfxHuella);
                item.SetActive(true);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //inhabilitar texto o mirar si ya lo hace en su variable
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Si has colocado la polvora podrá detectar al enemigo
            //Mejor no hacer con el activador porque si sales de la escena ya no puedes volver a activar dado que ya has gastado el item
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexGunpowder].modificacion)
            {
                huellas = true;
            }
        }
    }
}
