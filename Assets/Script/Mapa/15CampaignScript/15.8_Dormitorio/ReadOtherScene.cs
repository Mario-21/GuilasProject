using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadOtherScene : MonoBehaviour
{
    PlayerHere player;
    public int scenaRead;
    int contador;
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
        MostrarTextoNota();
        if (player.playerImHere)
        {
            //Boton de accion
            if (Input.GetKeyDown(KeyCode.Z))
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
                contador = 0;
                seeText = false;
                SceneManager.UnloadSceneAsync(scenaRead);
            }
            //Creo que solo debe hacer se una vez sino no puedes volver a cargarla si hay dos notas en la misma zona
        }
    }
    void MostrarTextoNota()
    {
        if (seeText && contador < 1)
        {
            SceneManager.LoadSceneAsync(scenaRead, LoadSceneMode.Additive);
            contador++;
        }
        else if (!seeText && contador >= 1)
        {
            SceneManager.UnloadSceneAsync(scenaRead);
            contador = 0;
        }
    }
    public KeepText Keeping()
    {
        KeepText conservarTexto = new KeepText();
        return conservarTexto;
    }
}
