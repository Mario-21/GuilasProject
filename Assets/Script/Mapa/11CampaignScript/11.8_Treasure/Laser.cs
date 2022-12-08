using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int indexMod;
    //Funcionamiento
    //Si colisionas con el laser llamara a un soldado en detrás de la puerta.
    bool playerOnLaser;
    [Header("Soldado Guardia Laser")]
    [SerializeField] Somnolencia soldadoLaser;
    [SerializeField] SoldadoNormal soldado;
    [Header("Lasers Move")]
    public Transform[] ubiLaser;
    public float speedLaser;
    int indexLaser;
    float timeUbi;
    public float timeUbiLimit;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            WakeUpSoldier();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveLaser();
        LaserOn();
    }
    void WakeUpSoldier()
    {
        soldadoLaser.enabled = false;
        soldado.enabled = true;
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
    void LaserOn()
    {
        if (playerOnLaser)
        {
            WakeUpSoldier();
        }
    }
    void MoveLaser()
    {
        ResetLaser();
        transform.position = Vector2.MoveTowards(transform.position, ubiLaser[indexLaser].position, speedLaser * Time.deltaTime);

        if (Vector2.Distance(ubiLaser[indexLaser].position, transform.position) < 1)
        {
            timeUbi += Time.deltaTime;
            if (timeUbi >= timeUbiLimit)
            {
                indexLaser++;
                timeUbi = 0;
            }
        }
    }
    void ResetLaser()
    {
        if(indexLaser >= ubiLaser.Length)
        {
            indexLaser = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnLaser = true;
        }
    }
}
