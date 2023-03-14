using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Header("Transicion")]
    public GameObject blackScreen;
    [Header("Data Next Scene")]
    public int checkpoint;
    public int nextScene;

    public bool startCin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startCin) DrawWeapon();
    }
    void DrawWeapon()
    {
        //Sacas el arma
        weapon.enabled = true;
        //Apunta con el arma
        brazo.rotation = new Quaternion(0f,0f,rotationZ,1f);
        //Inhabilita el movimiento para poder sacar el arma
        soldierMov.enabled = false;
        //Comienza el conteo
        timeShoot += Time.deltaTime;
        if(timeShoot >= timeShootLimit)
        {
            //Sonido del Disparo
            //Se corta de golpe la escena
            blackScreen.SetActive(true);
            //Coloca la variable de la cinematica en verdadero
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            //Establece la data para la siguiente escena
            CheckPointController.numeroCheckPoint = checkpoint;
            EstructuraNiveles.nivel = nextScene;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
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
