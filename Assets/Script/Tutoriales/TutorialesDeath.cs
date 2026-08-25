using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class TutorialesDeath : MonoBehaviour
{

    public string idTextoTutorial;

    public string archivoTutorialNombre;
    public string archiveTutorialName;

    public string spanishContent;
    public string englishContent;

    string idiomaGuardado;

    public Text textTutorial;



    public Animator tutorialAnim;

    public float timeLiveLimit;
    float timeLive;



    private void Start()
    {
        //Ruta Tutorial Español
        string rutaCompletaTutoSpanish = IdiomaGlobalManager.instanciaIdioma.rutaTutorialSpanish + archivoTutorialNombre + ".txt";
        spanishContent = File.ReadAllText(rutaCompletaTutoSpanish);
        //Ruta Tutorial English
        string routeCompleteTutoEnglish = IdiomaGlobalManager.instanciaIdioma.routeTutorialEnglish + archiveTutorialName + ".txt";
        englishContent = File.ReadAllText(routeCompleteTutoEnglish);


        tutorialAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        //EstablecerTextoIdioma
        //IdiomaGlobalManager.instanciaIdioma.SelectorTextoIdioma(ref idiomaGuardado, textTutorial, spanishContent, englishContent);
        //if (idiomaGuardado != IdiomaGlobalManager.instanciaIdioma.idiomaActual) TextoTraducido();
        IdiomaGlobalManager.instanciaIdioma.EstablecerTextosIdiomas(DataPersistenceManager.instance.interfaceDataText.tutorialesText, idTextoTutorial, textTutorial, ref idiomaGuardado);

        if(timeLive >= timeLiveLimit)
        {
            tutorialAnim.SetTrigger("Goodbye");
        }
        else
        {
            timeLive += Time.deltaTime;
        }

    }
    public void TutorialDeath()
    {
        ControlerTutoriales.instanciaTutoriales.colaTutoriales.Dequeue();
        Destroy(this.gameObject);
    }
}
