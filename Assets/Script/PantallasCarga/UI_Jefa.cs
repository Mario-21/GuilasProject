using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Jefa : MonoBehaviour
{
    public static UI_Jefa instanciaJefa;

    public EscribirPantallaCargaNiveles textPantalla;
    public Text textoUICarga;
    public string nameArchivo;
    public float velocidadLetra;
    public bool letraInvisible;
    public float tiempoEsperaLimite = 1;
    public float tiempoEspera;

    public ControladorListasNivel controladorListas;

    private void Awake()
    {
        
    }
    void Start()
    {
        controladorListas = FindObjectOfType<ControladorListasNivel>();
        //textPantalla.EscribirTexto(nameArchivo, textoUICarga, velocidadLetra, letraInvisible);
        //EscribirPantallaCarga();
        Invoke("EscribirPantallaCarga", 0.5f);
        //Debug.Log(Application.dataPath + "/Textos/Text_PantallaCarga/" + idiomaSelecionado + "/" + nameArchivo + ".txt");
        /*
        if(idiomaActual == idiomaSelecionado.ToString())
        {
            Debug.Log(idiomaSelecionado.ToString());
        }*/
        //IdiomaSelecionador(idiomaSelecionado.ToString());
        

    }
    private void Update()
    {
        if(textPantalla.escribirPantallaSolo.Count <= 0)
        {
            tiempoEspera += Time.deltaTime;
            if(tiempoEspera >= tiempoEsperaLimite)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                }
            }
        }
    }
    void EscribirPantallaCarga()
    {
        switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
        {
            case "Español":
                EscribirPantallaCargaNiveles.EscribirTextoStatic(IdiomaGlobalManager.rutaPantallaCargaSpanish, controladorListas.archivoNivelPantallaCarga, textoUICarga, velocidadLetra, letraInvisible);
                break;
            case "English":
                EscribirPantallaCargaNiveles.EscribirTextoStatic(IdiomaGlobalManager.rutaLoadScreenEnglish, controladorListas.archivoNivelPantallaCarga, textoUICarga, velocidadLetra, letraInvisible);
                break;
        }
    }
}
