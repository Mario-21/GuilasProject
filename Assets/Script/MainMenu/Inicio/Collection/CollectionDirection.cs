using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class CollectionDirection : MonoBehaviour
{
    [Header("File SFX")]
    [SerializeField] EventReference file_SFX;
    [Header("Flechas UI and Back")]
    public GameObject flechaIzquierda;
    public GameObject flechaDerecha;
    public Button backButton;
    [Header("Fila Principal")]
    public RectTransform fila;
    public float velocidad;
    [Space(10)]
    public List<RectTransform> carpeta_Pos;
    public List<Button> carpeta_Button;

    bool mover;
    public int indexFila;
    public static int posFila;
    public static bool repostDocs;
    public static bool botonDocs;

    [Header("File info")]
    [SerializeField] int actualFile;
    [SerializeField] int previousFile;
    [SerializeField] int nextFile;
    [Header("Sonido")]
    [SerializeField] int soundEffect;
    bool derechaFile;
    //NOTA; Es inversamente proporcional, si le doy a la derecha la fila se mueve hacía la izquierda;
    //Si le doy a la izquierda la fila se mueve a la derecha
    enum Orientation
    {
        izquierda,
        derecha
    }
    Orientation directionFila;
    void Start()
    {
        InfoFileStart();
        //Al darle a back regresamos a la misma carpeta
        fila.position = carpeta_Pos[posFila].position;
        mover = false;
        botonDocs = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Reglas de los sonidos
        //if (actualDocsPos != nextDocsPos
        if (actualFile != nextFile && derechaFile) InfoFilesDerecha();
        //actualDocsPos != previousDocsPos
        if (actualFile != previousFile && !derechaFile) InfoFilesIzquierda();

        //Cuando se muevan las carpetas hacer desaparecer las flechas?
        //Deberia añadir una animación manual de subida y baja, para tener un mayor feedback
        ReglasFlechas();
        ReglasButton();
        if (repostDocs) RecolocarPosDocs();
        /*
        NOTA:
        Se hace la mismo ejecucion en verdadero y falso debido a que si el jugador a presionado demasiado uno de los botones Izq/Drcha pueda seguir moviendose sin que se congele interfaz.
        */

        if (mover)
        {
            //Esto Solo puede hacerlo si tiene la reliquia
            switch (directionFila)
            {
                case Orientation.izquierda:
                    IzquierdaDirection();
                    break;
                case Orientation.derecha:
                    DerechaDirection();
                    break;
            }

        }
        else
        {
            switch (directionFila)
            {
                case Orientation.izquierda:
                    DerechaDirection();
                    break;
                case Orientation.derecha:
                    IzquierdaDirection();
                    break;
            }
        }
    }

    void IzquierdaDirection()
    {
        if (fila.position.x > carpeta_Pos[indexFila].position.x)
        {
            Debug.Log("Izquierda");
            fila.position = Vector2.MoveTowards(fila.position, carpeta_Pos[indexFila].position, velocidad * Time.deltaTime);
        }
        else
        {
            mover = false;
        }
    }
    public void DerechaButton()
    {
        derechaFile = true;
        mover = true;
        directionFila = Orientation.izquierda;
        if(indexFila < carpeta_Pos.Count - 1 )indexFila++;
    }
    void DerechaDirection()
    {
        if (fila.position.x < carpeta_Pos[indexFila].position.x)
        {
            Debug.Log("Derecha");
            fila.position = Vector2.MoveTowards(fila.position, carpeta_Pos[indexFila].position, velocidad * Time.deltaTime);
        }
        else
        {
            mover = false;
        }
    }
    public void IzquierdaButton()
    {
        derechaFile = false;
        mover = true;
        directionFila = Orientation.derecha;
        if(indexFila > 0 ) indexFila--;
    }
    void ReglasFlechas()
    {
        if(indexFila == 0)
        {
            flechaIzquierda.SetActive(false);
        }
        else
        {
            flechaIzquierda.SetActive(true);
        }
        if(indexFila == carpeta_Pos.Count - 1)
        {
            flechaDerecha.SetActive(false);
        }
        else
        {
            flechaDerecha.SetActive(true);
        }
    }
    void ReglasButton()
    {
        if (botonDocs)
        {
            backButton.enabled = true;
            flechaDerecha.GetComponent<Button>().enabled = true;
            flechaIzquierda.GetComponent<Button>().enabled = true;
            //SI mi indice actual coincide con uno de los botones activa dicho boton
            for (int i = 0; i < carpeta_Button.Count; i++)
            {
                //EL boton del indice actual se activa
                if (i == indexFila && ListaReliquias.instancia.listaReliquiasTotal[indexFila].reliquiaObtenida)
                {
                    Debug.Log("Trazacaminos " + i);
                    carpeta_Button[indexFila].enabled = true;
                }
                else
                {
                    carpeta_Button[i].enabled = false;
                }
            }
        }
        else
        {
            carpeta_Button[indexFila].enabled = false;
            flechaDerecha.GetComponent<Button>().enabled = false;
            flechaIzquierda.GetComponent<Button>().enabled = false;
            backButton.enabled = false;
        }
    }
    void InfoFilesDerecha()
    {
        if (fila.position.x <= carpeta_Pos[nextFile].position.x)
        {
            //Al llegar a la posicion, establece lo que era anteriormente su siguientePos como la actual.
            actualFile = nextFile;
            if (actualFile != 1) previousFile = previousFile + 1;
            if (actualFile < carpeta_Pos.Count - 1) nextFile = actualFile + 1;
            //Resetear parametros sonido
            soundEffect = 0;
        }
        else
        {
            if (mover)
            {
                if(soundEffect < 1)
                {
                    AudioManager.instancia.PlayOneShot(file_SFX);
                    soundEffect++;
                }
            }
        }
    }
    void InfoFilesIzquierda()
    {
        if (fila.position.x >= carpeta_Pos[previousFile].position.x)
        {
            //Al llegar a la posicion, establece lo que era anteriormente su siguientePos como la actual.
            actualFile = previousFile;
            if (actualFile != carpeta_Pos.Count - 2) nextFile = nextFile - 1;
            if (actualFile > 0) previousFile = actualFile - 1;
            //Resetear Parametros del sonido
            soundEffect = 0;
        }
        else
        {
            if (mover)
            {
                if(soundEffect < 1)
                {
                    AudioManager.instancia.PlayOneShot(file_SFX);
                    soundEffect++;
                }
            }
        }
    }
    void InfoFileStart()
    {
        actualFile = 0;
        previousFile = 0;
        nextFile = actualFile + 1;
    }
    void RecolocarPosDocs()
    {
        fila.position = carpeta_Pos[posFila].position;
        indexFila = posFila;
        repostDocs = false;
    }
    private void OnDisable()
    {
        posFila = 0;
        Debug.Log("On didable Zero");
    }
}
