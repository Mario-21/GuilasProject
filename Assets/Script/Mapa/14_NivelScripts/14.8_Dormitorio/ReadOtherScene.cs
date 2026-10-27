using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadOtherScene : MonoBehaviour
{
    PlayerHere player;
    public int scenaRead;
    public int contador;
    [TextArea(2,10)]
    public string[] textoNota;

    bool seeText;

    //Tambien podría simplemente colocar el texto en cada escena que se use un texto de manera adicional, pero quiero probar esta mierda 

    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FixNoteBug();
        if (player.playerImHere)
        {
            //Boton de accion
            if (Input.GetButtonDown("Action"))
            {
                seeText = !seeText;
                //Colocar Texto
                Keeping().KeepTextCadena(textoNota);
                //Deberia tener 
                MostrarTextoNota();

                //Read.cadenaTexto[0] = textoNota[0];
                //Probar el intermediario con un script que no sea monobehavier, ya se intentara
            }
        }
        else
        {
            if(contador >= 1)
            {

                //NOTA: Esta condicion se ha hecho para evitar un bug, en el que si presionas el boton de accion en el borde del trigger se puede quedar pillada la pantalla del texto.
                SceneManager.UnloadSceneAsync(scenaRead);
                seeText = false;
                if (!SceneManager.GetSceneByBuildIndex(scenaRead).isLoaded) 
                {
                    Debug.Log("AlphaSniper");
                    contador = 0;
                }
            }
            //Creo que solo debe hacer se una vez sino no puedes volver a cargarla si hay dos notas en la misma zona
        }
    }
    void MostrarTextoNota()
    {
        if (seeText)
        {
            SceneManager.LoadSceneAsync(scenaRead, LoadSceneMode.Additive);
            contador++;
        }
        else
        {
            SceneManager.UnloadSceneAsync(scenaRead);
            contador = 0;
        }
    }
    void FixNoteBug()
    {
        if(contador == 0 && SceneManager.GetSceneByBuildIndex(scenaRead).isLoaded)
        {
            SceneManager.UnloadSceneAsync(scenaRead);
        }
    }
    public KeepText Keeping()
    {
        KeepText conservarTexto = new KeepText();
        return conservarTexto;
    }
}
