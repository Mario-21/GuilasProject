using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador_Tiempo_Visual : MonoBehaviour
{

    public NoviceSoldier noviceContador;
    public SpriteRenderer barraContador;
    public float sizeXBarra;
    float conversorTiempo;
    [Header("Peligro Muerte")]
    public GameObject calaveraAnim;
    public GameObject calaveraNormal;
    public Animator animCalavera;
    [Header("Oxigeno Pantalla")]
    public GameObject oxygenScreen;
    // Start is called before the first frame update
    void Start()
    {
        noviceContador = FindObjectOfType<NoviceSoldier>();
        /*
        barraRelleno.color = Color.yellow;
        conversorTiempo = tiempoNecesarioLlamar * sizeXBarra / tiempoNecesarioLlamarLimite;
        barraRelleno.size = new Vector2(conversorTiempo, barraRelleno.size.y);
        tiempoNecesarioLlamar += Time.deltaTime;*/
        //FinDelTiempoMinus();
    }

    // Update is called once per frame
    void Update()
    {
        ContadorVisual();
        CalaveraPeligroDeath();
    }
    void ContadorVisual()
    {
        conversorTiempo = noviceContador.timeNoviceDeath * sizeXBarra / noviceContador.limitTimeDeathNovice;
        barraContador.size = new Vector2(conversorTiempo, barraContador.size.y);
    }
    void CalaveraPeligroDeath()
    {
        //Mientras no se haya detenido que ejecute las animaciones de la pantalla
        //Esto se hace, ya que, si se da el caso de que has terminado la cinemática con el tiempoMinus, las animaciones no se desactivan.
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[noviceContador.indexStop].modificacion)
        {
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[noviceContador.indexExceedTime].modificacion)
            {
                float minutoPeligro;
                minutoPeligro = noviceContador.limitTimeDeathNovice - 60;

                if (noviceContador.timeNoviceDeath > minutoPeligro)
                {
                    calaveraAnim.SetActive(true);
                }
            }
        }
        else
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[noviceContador.indexMinusTime].modificacion)
            {
                barraContador.color = Color.green;
                calaveraAnim.SetActive(false);
                oxygenScreen.SetActive(false);
            }
            else if (StatusGameobjectsVariables.statusGameobject.modificacion[noviceContador.indexExceedTime].modificacion)
            {
                calaveraAnim.SetActive(false);
                calaveraNormal.SetActive(true);
            }
        }
        
    }
}
