using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunpowderUse : MonoBehaviour
{
    public int indexMod;
    [Tooltip("Se necesita una accion previa para activarlo")]
    public int indexGunpowder;
    [Header("Item")]
    [SerializeField] GameObject item;
    [Header("Tiempo Dejar Huellas")]
    public float timeHuellasLimit;
    float timeHuellas;

    PlayerHere player;
    bool huellas;

    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            item.SetActive(true);
            this.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.playerImHere)FingerPrints();
    }
    void FingerPrints()
    {
        if (huellas)
        {
            timeHuellas += Time.deltaTime;
            if(timeHuellas >= timeHuellasLimit)
            {
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
