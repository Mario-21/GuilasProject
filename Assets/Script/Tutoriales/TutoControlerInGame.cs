using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class TutoControlerInGame : MonoBehaviour
{
    public bool spawnQeueu;
    public bool addQeueu;
    public bool deleteQeueu;
    public bool petar;
    public static bool tutoActive;
    public static GameObject tutoActual;
    public Queue<GameObject> colacomando;
    public static TutoControlerInGame instancia;
    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;

    public string nextQueue;

    public GameObject queueObject;
    void Start()
    {
        
        colacomando = new Queue<GameObject>();
        //colacomando.FirstOrDefault(t => t == gameObject);
        //ControlerTutoriales.instanciaTutoriales.colaTutoriales.Enqueue(item_1);
        colacomando.Enqueue(item_1);
        colacomando.Enqueue(item_2);
        colacomando.Enqueue(item_3);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnQeueu)
        {
            Debug.Log(colacomando.Peek().name);
            nextQueue = colacomando.Peek().name; //ControlerTutoriales.instanciaTutoriales.colaTutoriales.Peek().name; 
            //colacomando.Dequeue();

            spawnQeueu = false;
        }

        if (addQeueu)
        {
            /*
            ControlerTutoriales.instanciaTutoriales.colaTutoriales.Enqueue(item_1);
            ControlerTutoriales.instanciaTutoriales.colaTutoriales.Enqueue(item_2);
            ControlerTutoriales.instanciaTutoriales.colaTutoriales.Enqueue(item_3);
            */
            colacomando.Enqueue(item_1);
            addQeueu = false;
        }
        if (deleteQeueu)
        {
            //ControlerTutoriales.instanciaTutoriales.colaTutoriales.Dequeue();
            colacomando.Dequeue();
            deleteQeueu = false;
        }
        if (petar)
        {
            if (colacomando.Count > 0)
            {
                if (!queueObject)
                {
                    queueObject = Instantiate(colacomando.FirstOrDefault());
                }
            }
        }
        /*
        if (!queueObject)
        {
            queueObject = Instantiate(colacomando.FirstOrDefault());
        }
        */
        /*
        if(tutoActual != null)
        {
            Debug.Log("Existo y soy " + tutoActual.name);
        }
        else
        {
            Debug.Log("No existo");
        }*/
    }
}
