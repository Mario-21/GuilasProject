using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ShootEnemyCIn : MonoBehaviour
{
    public int indexMod;
    [Header("Soldier Data")]
    [SerializeField] SpriteRenderer weapon;
    [SerializeField] Transform brazo;
    [SerializeField] SoldadoNormal soldierMov;
    public float rotationZ;
    [Header("Tiempo Shoot")]
    public float timeShootLimit;
    public float timeShoot;
    [Header("Tiempo Flesh")]
    public float timeFleshLimit;
    [Header("Tiempo End")]
    public float timeEndLimit;
    [Header("Transicion")]
    public GameObject blackScreen;
    [Header("Data Next Scene")]
    public int checkpoint;
    public int nextScene;
    [Header("SFX Shoot End")]
    [SerializeField] EventReference shoot_End;
    [SerializeField] EventReference flesh_End;

    public bool startCin;
    int onceShoot;

    enum SecuenceShootEnemy
    {
        Draw_Shot,
        Flesh,
        End,
        Default
    }
    SecuenceShootEnemy actualSecuence;
    void Update()
    {
        if(startCin) SecuenceWeapon();
    }
    void SecuenceWeapon()
    {
        switch (actualSecuence)
        {
            case SecuenceShootEnemy.Draw_Shot:
                //Sacas el arma
                weapon.enabled = true;
                //Apunta con el arma
                brazo.rotation = new Quaternion(0f, 0f, rotationZ, 1f);
                //Inhabilita el movimiento para poder sacar el arma
                soldierMov.enabled = false;
                //Comienza el conteo
                if (timeShoot >= timeShootLimit)
                {
                    //Sonido del Disparo
                    //Se corta de golpe la escena
                    blackScreen.SetActive(true);
                    AudioManager.instancia.PlayOneShot(shoot_End);
                    actualSecuence = SecuenceShootEnemy.Flesh;
                    timeShoot = 0;
                }
                else
                {
                    timeShoot += Time.deltaTime;
                    if (onceShoot < 1)
                    {
                        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.drawWeapon);
                        onceShoot++;
                    }
                }
                break;
            case SecuenceShootEnemy.Flesh:
                if(timeShoot >= timeFleshLimit)
                {
                    AudioManager.instancia.PlayOneShot(flesh_End);
                    actualSecuence = SecuenceShootEnemy.End;
                    timeShoot = 0;
                }
                else
                {
                    timeShoot += Time.deltaTime;
                }
                break;
            case SecuenceShootEnemy.End:
                if(timeShoot >= timeEndLimit)
                {
                    //Coloca la variable de la cinematica en verdadero
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    //Establece la data para la siguiente escena
                    CheckPointController.numeroCheckPoint = checkpoint;
                    EstructuraNiveles.nivel = nextScene;
                    AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                    actualSecuence = SecuenceShootEnemy.Default;
                }
                else
                {
                    timeShoot += Time.deltaTime;
                }
                break;
            case SecuenceShootEnemy.Default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Crocus");
            startCin = true;
        }
    }
}
