using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class TutorialesDeath : MonoBehaviour
{

    public string archivoTutorialNombre;
    public string archiveTutorialName;

    public string spanishContent;
    public string englishContent;

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
        EstablecerTextoIdioma();

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
    public void EstablecerTextoIdioma()
    {
        //Aquí hay que añadir que cuando el tiempo de spawn llegue a 0, adicionalmente lo quite de la queue del ControlerTutoriales, porque sino, dicha
        //queue quedará como vacía

        switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual) //--------->colocar un void general que pida un text +string Español + string Ingles.
        {
			case "Español":
			textTutorial.text = spanishContent;
            break;
			case "English":
			textTutorial.text = englishContent;
            break;
        }
    }
}
