using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ControlerTutoriales : MonoBehaviour
{
    public static ControlerTutoriales instanciaTutoriales;
    
    public Queue<GameObject> colaTutoriales;
    GameObject queueTutorialObject;
    [Header("Id Individual")]
    [Tooltip("Esto solo sirve por si hay que añadir alguna id extra, para no tener que hacer todo el recorrido")]
    public int indexGenerarID;
    //No puedo colocar el icono aquí porque necesito buscarlo anteriormente y cada vez que cambio de escena elimino el Ui del jugador,
    //Además de solo poder ejecutarlo
    //Colocar en en el flecha de la UI la condición, si existe la lista y la cola es superior a 1 que aparezca el icono sino no

    [Header("Lista Tutoriales Nivel")]
    public List<TutoInfo> infoTutoNivel;
    public List<TutoInfo> infoTutoInicial;

    private void Awake()
    {
        if (ControlerTutoriales.instanciaTutoriales == null)
        {
            ControlerTutoriales.instanciaTutoriales = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        colaTutoriales = new Queue<GameObject>();
    }
    void Start()
    {
        //colaTutoriales = new Queue<GameObject>();
        for (int i = 0; i < infoTutoNivel.Count; i++)
        {
            TutoInfo tutoInfo = new TutoInfo();
            tutoInfo.nameTuto = infoTutoNivel[i].nameTuto;
            tutoInfo.idTuto = infoTutoNivel[i].idTuto;
            GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(infoTutoNivel[i].idTuto, out tutoInfo.tutoDesbloqueado);

            infoTutoInicial.Add(tutoInfo);

            if (infoTutoInicial[i].tutoDesbloqueado)
            {
                infoTutoNivel[i].tutoDesbloqueado = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Esto se hace para que cuando te vayas de escena y hayas pasado por varios trigger de tutoriales,
        //la información se acumule, asi no se perdera. Adicionalmente la ira spawneando poco a poco para 
        //que no pierdas la información al cambiar de escena
        
        if (colaTutoriales.Count > 0)
        {
            //Esto es un icono que muestra que aun queda más información por mostrar.
            //iconoQueueAcumulada.SetActive(true);
            if (!queueTutorialObject)
            {
                queueTutorialObject = Instantiate(colaTutoriales.FirstOrDefault());
            }

            /*
            if (!colaTutoriales.FirstOrDefault().activeInHierarchy)
            {
                Instantiate(colaTutoriales.FirstOrDefault());
            }
            */
        }
        
    }
    public void ResetearTutoriales()
    {
        colaTutoriales.Clear();
        for (int i = 0; i < infoTutoNivel.Count; i++)
		{
            if (!infoTutoInicial[i].tutoDesbloqueado)
            {
                infoTutoNivel[i].tutoDesbloqueado = false;
                if (GameDataNoDestroy.instance.gameData.tutorialesCollected.ContainsKey(infoTutoNivel[i].idTuto))
                {
                    GameDataNoDestroy.instance.gameData.tutorialesCollected.Remove(infoTutoNivel[i].idTuto);
                }
                GameDataNoDestroy.instance.gameData.tutorialesCollected.Add(infoTutoNivel[i].idTuto, infoTutoInicial[i].tutoDesbloqueado);

            }
            else
            {
                Debug.Log("El tutorial " + infoTutoNivel[i].idTuto + " ya se ha desbloqueado");
            }
        }
    }

    [ContextMenu("Genera una ID aleatoria a todos los tutoriales")]
    private void GenerarIDTutoriales()
    {
        for (int i = 0; i < infoTutoNivel.Count; i++)
        {
            infoTutoNivel[i].nameTuto = "Tutorial_";
            infoTutoNivel[i].idTuto = "";
            int limiteCharacter = 0;
            string id = System.Guid.NewGuid().ToString();
            foreach (char character in id)
            {
                if (limiteCharacter <= 8)
                {
                    Debug.Log(limiteCharacter);
                    infoTutoNivel[i].idTuto  += character;
                    limiteCharacter++;
                }
            }
        }
    }
    [ContextMenu("Genera una ID aleatoria de un tutorial")]
    private void GenerarIDTutorialIndividual()
    {
        infoTutoNivel[indexGenerarID].nameTuto = "Tutorial_";
        infoTutoNivel[indexGenerarID].idTuto = "";
        int limiteCharacter = 0;
        string id = System.Guid.NewGuid().ToString();
        foreach (char character in id)
        {
            if (limiteCharacter <= 8)
            {
                Debug.Log(limiteCharacter);
                infoTutoNivel[indexGenerarID].idTuto += character;
                limiteCharacter++;
            }
        }
    }
}
[System.Serializable]
public class TutoInfo
{
    public string nameTuto;
    public string idTuto;
    public bool tutoDesbloqueado;
}