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
    int vacio;
    public enum idioma
    {
        Español,
        Ingles
    }
    public idioma idiomaSelecionado;

    public string idiomaActual;

    void Start()
    {

        
        //textPantalla.EscribirTexto(nameArchivo, textoUICarga, velocidadLetra, letraInvisible);
        EscribirPantallaCargaNiveles.EscribirTextoStatic(idiomaSelecionado.ToString(), nameArchivo, textoUICarga, velocidadLetra, letraInvisible);
        //Debug.Log(Application.dataPath + "/Textos/Text_PantallaCarga/" + idiomaSelecionado + "/" + nameArchivo + ".txt");
        /*
        if(idiomaActual == idiomaSelecionado.ToString())
        {
            Debug.Log(idiomaSelecionado.ToString());
        }*/
        //IdiomaSelecionador(idiomaSelecionado.ToString());
        

    }
    public void IdiomaSelecionador(string dospados)
    {
        Debug.Log("Pagudo " + dospados);
    }

}
