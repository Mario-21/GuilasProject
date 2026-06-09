using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EscribirPantallaCargaNiveles : MonoBehaviour
{
    private static EscribirPantallaCargaNiveles instanciaEscribirPantalla;

    private List<EscribirPantallaSolo> escribirPantallaSolo;

    private void Awake()
    {
        instanciaEscribirPantalla = this;
        escribirPantallaSolo = new List<EscribirPantallaSolo>();
    }
    void Start()
    {
        //textoDelDocumento = Application.dataPath + "/Textos/Text_PantallaCarga/" + pantallaCargaName + ".txt";
        //textPantallasCarga.text = File.ReadAllText(textoDelDocumento);
        //contenidoTextPantallaCarga = textPantallasCarga.text;
        //Debug.Log(textPantallasCarga.text.Substring(5, 10));
        //Debug.Log(contenidoTextPantallaCarga.Length);
    }

    public static void EscribirTextoStatic(string rutaIdioma,string rutaTexto, Text textoUI, float velocidadLetra, bool letrasInvisibles)
    {
        instanciaEscribirPantalla.EscribirTexto(rutaIdioma,rutaTexto, textoUI,velocidadLetra,letrasInvisibles);
    }
    public void EscribirTexto(string rutaIdioma,string rutaTexto, Text textoUI, float velocidadLetra,bool letrasInvisibles)
    {
        //escribirPantallaSolo.EscribirPantallaCargaSola_2(rutaTexto, textoUI, velocidadLetra, letrasInvisibles);
        escribirPantallaSolo.Add(new EscribirPantallaSolo(rutaIdioma, rutaTexto, textoUI,velocidadLetra,letrasInvisibles));
    }
    private void Update()
    {
        for (int i = 0; i < escribirPantallaSolo.Count; i++)
        {
           bool destruirInstancia = escribirPantallaSolo[i].Update();
            if (destruirInstancia)
            {
                escribirPantallaSolo.RemoveAt(i);
                i--;
            }
        }
        /*
        if(escribirPantallaSolo != null)
        {
            escribirPantallaSolo.Update();
        }*/
    }
    public class EscribirPantallaSolo
        {
        [Header("Nombre del Archivo del Texto")]
        private string pantallaCargaName;
        string textoDelDocumento;
        [Header("Texto UI")]
        Text textPantallasCarga;
        string contenidoTextPantallaCarga;
        [Header("Velocidad Letra")]
        private int indexLetras;
        private float velocidadLetras;
        private bool letrasInvisibles;
        [Header("Tiempo en pantalla Textos")]
        private float timePerCharacter;
        private float timer;
        public EscribirPantallaSolo(string rutaIdioma,string rutaTexto, Text textoUI, float velocidadLetra, bool letrasInvisibles)
        {
            this.textPantallasCarga = textoUI;
            textoDelDocumento = Application.dataPath + "/Textos/Text_PantallaCarga/" + rutaIdioma + "/" + rutaTexto + ".txt";
            textoUI.text = File.ReadAllText(textoDelDocumento);
            this.contenidoTextPantallaCarga = textoUI.text;
            this.timePerCharacter = velocidadLetra;
            this.letrasInvisibles = letrasInvisibles;
            indexLetras = 0;
        }
        public bool Update()
        {
            //Si hay algo escrito en el texto
            
                timer -= Time.deltaTime;
                while (timer < 0f)
                {
                    //Aparece la siguiente letra
                    //Aumenta el index para pasar a la siguiente letra
                    indexLetras++;
                    //Resetea el timer
                    timer = timePerCharacter;
                    //textPantallasCarga.text = contenidoTextPantallaCarga.Substring(0, indexLetras);
                    //Debug.Log(textPantallasCarga.text.Length);
                    //En cuanto el index sea mayor quiere decir que ya no queda nada por escribir.
                    if (indexLetras > contenidoTextPantallaCarga.Length)
                    {
                        //Debug.Log("<color=#00000000>" + "</color>");
                        //textPantallasCarga = null;
                        return true;
                    }
                    else
                    {
                        string texto = contenidoTextPantallaCarga.Substring(0, indexLetras);
                        if (letrasInvisibles)
                        {
                            texto += "<color=#00000000>" + contenidoTextPantallaCarga.Substring(indexLetras) + "</color>";
                        }
                        textPantallasCarga.text = texto;
                    }

                }
            return false;
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (textPantallasCarga != null) textPantallasCarga.text = contenidoTextPantallaCarga;
                indexLetras = contenidoTextPantallaCarga.Length;

                Debug.Log("He presionado la K y ha aparecido el texto directamente");
            }
        }
    }
}
