using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DisplayTutorial : MonoBehaviour
{
	public string idTutorial;
	public Text textoTutorial;
	bool desbloqueado;

	[Header("Imagen Tutorial")]
	public Image imageScreen;
	public Sprite imageTutorial;

	[Header("Boton Estado Tutorial")]
	public GameObject botonLock;
	public GameObject botonUnlock;

	[Header("Archivos Textos")]
	public string nombreSpanish;
	string contentSpanish;
	public string nameEnglish;
	string contentEnglish;

	//Quizas meteré dentro del GameNoDestroy todos los textos relacionados, paracido a lo que hago con los nombres Items de GameData
	// Start is called before the first frame update
	void Start()
    {
		//Primero revisamos si ya se había desbloqueado anteriormente
		GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(idTutorial, out desbloqueado);
		if (desbloqueado)
		{
			//Si has desbloqueado un tutorial se muestra el boton para poder mostrartelo
			botonUnlock.SetActive(true);
			botonLock.SetActive(false);

			//Ruta Archivo Español
			string rutaCompletaTutoSpanish = IdiomaGlobalManager.instanciaIdioma.rutaTutorialSpanish + nombreSpanish;
			contentSpanish = File.ReadAllText(rutaCompletaTutoSpanish);

			//Ruta Archivo English
			string routeCompleteTutoEnglish = IdiomaGlobalManager.instanciaIdioma.routeTutorialEnglish + nameEnglish;
			contentEnglish = File.ReadAllText(routeCompleteTutoEnglish);

		}
		else
		{
			//Si no lo has desbloqueado aparecerá un boton con un candado que muestre
			botonUnlock.SetActive(false);
			botonLock.SetActive(true);
		}
	}
	public void SelectTutorial()
	{
		//Establece la imagen referente del tutorial
		imageScreen.sprite = imageTutorial;
		
		switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
		{
			case "Español":
				textoTutorial.text = contentSpanish;
				break;
			case "English":
				textoTutorial.text = contentEnglish;
				break;
		}
	}
}
