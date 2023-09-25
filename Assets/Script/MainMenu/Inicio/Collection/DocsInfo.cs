using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class DocsInfo : MonoBehaviour
{
    [Header("SFX Flechas")]
    [SerializeField] EventReference sfx_Flechas;
    [Header("Flechas UI")]
    public GameObject flechaIzquierda;
    public GameObject flechaDerecha;
    [Header("Fila Principal")]
    public RectTransform filaDocs;
    public float velocidad;
    [Space(10)]
    public List<DocsPosListBase> docsBase;
    [Tooltip("Se coloca la posicion de imagen y texto de cada uno de los documentos en la escena")]
    public List<DocsData> docsIndividual;
    public List<DocsDown> docsDown;
    public List<CanvasGroup> canvasText;

    bool mover;
    public int indexFilaDocs;
    public int reliquiasObtenidas;
    public static int docsPosStart;
    //NOTA; Es inversamente proporcional, si le doy a la derecha la fila se mueve hacía la izquierda;
    //Si le doy a la izquierda la fila se mueve a la derecha
    [Header("Info de la Position")]
    [SerializeField] int actualDocsPos;
    [SerializeField] int nextDocsPos;
    [SerializeField] int previousDocsPos;
    [Header("Info Sound")]
    [SerializeField] int soundDocs;
    bool derechaDocs;
    enum Orientation
    {
        izquierda,
        derecha
    }
    Orientation directionFila;
    void Start()
    {
        //Checkea las reliquias para comprobar en que posicion debe colocar los documentos 
        ReliquiasHave();
        //Establece el spawn en base al documento selecionado
        filaDocs.position = docsBase[docsPosStart].posDocs.position;
        //La fila se establece igual a la posicion de los documentos
        indexFilaDocs = docsPosStart;
        InfoDocsStart();
    }
    void Update()
    {
        //Para poder acceder a la escena de documentos previamente has tenido que obtener uno, por tanto se tiene que siempre
        //Solo puede dar a error si yo accedo manualmente a ella
        if (actualDocsPos != nextDocsPos && derechaDocs) InfoDocsPositionDerecha();
        if (actualDocsPos != previousDocsPos && !derechaDocs) InfoDocsPositionIzquierda();
        CanvasGroupShow();
        ReglasFlecha();
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
        if (filaDocs.position.x > docsBase[indexFilaDocs].posDocs.position.x)
        {
            Debug.Log("Izquierda");
            filaDocs.position = Vector2.MoveTowards(filaDocs.position, docsBase[indexFilaDocs].posDocs.position, velocidad * Time.deltaTime);
        }
        else
        {
            mover = false;
        }
    }
    public void DerechaButton()
    {
        //AudioManager.instancia.PlayOneShot(sfx_Flechas);
        derechaDocs = true;
        canvasText[indexFilaDocs].alpha = 0;
        mover = true;
        //Inversamente proporcional
        directionFila = Orientation.izquierda;
        if (indexFilaDocs < reliquiasObtenidas - 1) indexFilaDocs++;
    }
    void DerechaDirection()
    {
        if (filaDocs.position.x < docsBase[indexFilaDocs].posDocs.position.x)
        {
            Debug.Log("Derecha");
            filaDocs.position = Vector2.MoveTowards(filaDocs.position, docsBase[indexFilaDocs].posDocs.position, velocidad * Time.deltaTime);
        }
        else
        {
            mover = false;
        }
    }
    public void IzquierdaButton()
    {
        derechaDocs = false;
        //Para reproducir el audio tiene que tener en cuenta que es cuando el papel ha llegado a la posicion y se vuelve a mover
        //AudioManager.instancia.PlayOneShot(sfx_Flechas);
        canvasText[indexFilaDocs].alpha = 0;

        mover = true;
        directionFila = Orientation.derecha;
        if (indexFilaDocs > 0) indexFilaDocs--;
    }
    void ReliquiasHave()
    {
        //Esta misma ejecucion se aplicaria en la hora de seleccionar una carpeta.
        //Basicamente recorres las reliquias, miras a ver cuantas tienes y se la asignas al boton de la carpeta para que aparezca en la posicion correspondiente en base al numero de reliquias que hayas obtenido
        //posicion de la fila se elige de manera externa
        for (int i = 0; i < docsBase.Count; i++)
        {
            if (ListaReliquias.instancia.listaReliquiasTotal[i].reliquiaObtenida)
            {
                //Coloca la Imagen del Documento en su respectiva posicion
                docsIndividual[i].docsImage.position = docsBase[reliquiasObtenidas].posDocsImageBase.position;
                //Coloca la Texto del Documento en su respectiva posicion
                docsIndividual[i].docsText.position = docsBase[reliquiasObtenidas].posDocsTextBase.position;
                //Coloca la CarpetBack del Documento en su respectiva posicion
                docsIndividual[i].docsCarpet.position = docsBase[reliquiasObtenidas].posCarpetBackBase.position;
                //Añade los canvas canvas para saber cuales deben interactuar
                canvasText.Add(docsIndividual[i].docsText.GetComponent<CanvasGroup>());
                //Asignar la ubicacion a la que se tienen que mover
                docsDown[i].posNext = docsBase[reliquiasObtenidas].posDocsImageNext;

                reliquiasObtenidas++;
            }
            else
            {
                docsIndividual[i].docsCarpet.gameObject.SetActive(false);
                docsIndividual[i].docsImage.gameObject.SetActive(false);
                docsIndividual[i].docsText.gameObject.SetActive(false);
            }
        }
    }
    void CanvasGroupShow()
    {
        if (!mover && filaDocs.position.x > docsBase[indexFilaDocs].posDocs.position.x - 1 && filaDocs.position.x < docsBase[indexFilaDocs].posDocs.position.x + 1)
        {
            canvasText[indexFilaDocs].alpha += 0.01f;
        }
    }
    void ReglasFlecha()
    {
        if (indexFilaDocs == 0)
        {
            flechaIzquierda.SetActive(false);
        }
        else
        {
            flechaIzquierda.SetActive(true);
        }
        if (indexFilaDocs == reliquiasObtenidas - 1)
        {
            flechaDerecha.SetActive(false);
        }
        else
        {
            flechaDerecha.SetActive(true);
        }
    }
    void InfoDocsPositionDerecha()
    {
        //limitar para que el audio solo se reproduzca una vez
        //Hacer lo mismo a la izquierda calores invertidos
        //Cuando haya llegado y superado la siguientePos de los Documentos filaDocs.position.x < docsBase[indexFilaDocs].posDocs.position.x
        if (filaDocs.position.x <= docsBase[nextDocsPos].posDocs.position.x)
        {
            //Al llegar a la posicion, establece lo que era anteriormente su siguientePos como la actual.
            actualDocsPos = nextDocsPos;
            if (actualDocsPos != 1) previousDocsPos = previousDocsPos + 1;
            if(actualDocsPos < reliquiasObtenidas - 1) nextDocsPos = actualDocsPos + 1;
            //Resetear Parametros del sonido
            soundDocs = 0;
        }
        else
        {
            //Si has comenzado a moverte y no has llegado a la siguiente posicion quiere decir que te estas moviendo
            //Entonces reproduce el audio
            if (mover)
            {
                if(soundDocs < 1)
                {
                    AudioManager.instancia.PlayOneShot(sfx_Flechas);
                    soundDocs++;
                }
            }
        }
        //Esto lo tiene que hacer cada vez que se llegue a la nextpositionDOcs
    }
    void InfoDocsPositionIzquierda()
    {
        if (filaDocs.position.x >= docsBase[previousDocsPos].posDocs.position.x)
        {
            //Al llegar a la posicion, establece lo que era anteriormente su siguientePos como la actual.
            actualDocsPos = previousDocsPos;
            if (actualDocsPos != reliquiasObtenidas - 2) nextDocsPos = nextDocsPos - 1;
            if (actualDocsPos > 0) previousDocsPos = actualDocsPos - 1;
            //Resetear Parametros del sonido
            soundDocs = 0;
        }
        else
        {
            //Si has comenzado a moverte y no has llegado a la siguiente posicion quiere decir que te estas moviendo
            //Entonces reproduce el audio
            if (mover)
            {
                if (soundDocs < 1)
                {
                    AudioManager.instancia.PlayOneShot(sfx_Flechas);
                    soundDocs++;
                }
            }
        }
    }
    void InfoDocsStart()
    {
        //Primero establece la posicion del documento 
        actualDocsPos = docsPosStart;
        if(actualDocsPos <= 0)
        {
            previousDocsPos = actualDocsPos;
        }
        else
        {
            previousDocsPos = actualDocsPos - 1;
        }
        //Si al entrar mi posicion actual es diferente al numero maximo de reliquia, quiere decir que no te has establecido en el limite de los documentos 
        if(actualDocsPos != reliquiasObtenidas - 1)
        {
            nextDocsPos = actualDocsPos + 1;
        }
        //Entras en la documentacion justo en el limite
        else
        {
            nextDocsPos = actualDocsPos;
        }
    }
    void Garabato()
    {
        if (filaDocs.position.x < docsBase[nextDocsPos].posDocs.position.x)
        {
            Debug.Log("la fila es mas pequeña que...");
        }
        else
        {
            Debug.Log("la filaDocs es " + filaDocs.position.x);
            Debug.Log("la docsBase es " + docsBase[nextDocsPos].posDocs.position.x);
        }
    }
}
