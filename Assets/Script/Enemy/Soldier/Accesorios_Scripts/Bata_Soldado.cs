using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bata_Soldado : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldado;
    Animator bataAnim;

    [Header("Tiempo Registro")]
    public float tiempoRegistroLimite;
    float tiempoRegistro;

    float ubiSaveActual;
    float lastUbiSave;

    // Start is called before the first frame update
    void Start()
    {
        bataAnim = GetComponent<Animator>();
        ubiSaveActual = soldado.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        RegistrarUbicacion();
        CaminarBata();
    }
    void CaminarBatas()
    {
        if (soldado.movimiento)
        {
            bataAnim.SetBool("BataCaminar", true);
        }
        else
        {
            bataAnim.SetBool("BataCaminar", false);
        }
    }
    void RegistrarUbicacion()
    {
        tiempoRegistro += Time.deltaTime;

        if(tiempoRegistro >= tiempoRegistroLimite)
        {
            lastUbiSave = ubiSaveActual;
            ubiSaveActual = soldado.transform.position.x;
            tiempoRegistro = 0;
        }
    }
    void CaminarBata()
    {
        if (soldado.movimiento)
        {
            //A la izquierda
            bataAnim.SetBool("BataCaminar", true);
            if(soldado.transform.localScale.x == -1)
            {
                if (lastUbiSave > ubiSaveActual)
                {
                    //El Soldado retrocede mientras me esta mirando.
                    //Bata Laboratorio (MovInterior)
                    //bataAnim.SetBool("Seguir", false);
                    bataAnim.SetBool("Seguir", true);
                }
                else if (lastUbiSave < ubiSaveActual)
                {
                    //El Soldado sigue al jugador.
                    //Bata Laboratorio(Mov)
                    bataAnim.SetBool("Seguir", false);
                }
            }
            //A la derecha 
            else if (soldado.transform.localScale.x == 1)
            {
                if (lastUbiSave > ubiSaveActual)
                {
                    //El Soldado retrocede mientras me esta mirando.
                    //Bata Laboratorio (MovInterior)
                    //bataAnim.SetBool("Seguir", false);
                    bataAnim.SetBool("Seguir", false);
                }
                else if (lastUbiSave < ubiSaveActual)
                {
                    //El Soldado sigue al jugador.
                    //Bata Laboratorio(Mov)
                    bataAnim.SetBool("Seguir", true);
                }
            }
        }
        else
        {
            bataAnim.SetBool("BataCaminar", false);
            //bataAnim.SetBool("BataCaminar", false);
        }
    }
}
