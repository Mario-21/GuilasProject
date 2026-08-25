using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DisplayTutorial : MonoBehaviour
{
	public string idTutorial;
	public string idTutorialText;
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

	string idiomaGuardado;

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

		IdiomaGlobalManager.instanciaIdioma.SelectorTextoIdioma(ref idiomaGuardado, textoTutorial, contentSpanish, contentEnglish);
	}
	public void SelectorTutorialIdTexto()
	{
		//Establece la imagen referente del tutorial
		imageScreen.sprite = imageTutorial;

		IdiomaGlobalManager.instanciaIdioma.EstablecerTextosIdiomas(DataPersistenceManager.instance.interfaceDataText.tutorialesText, idTutorialText, textoTutorial, ref idiomaGuardado);
	}
	//void TextoTraducido(InterfaceText textData)
	void TextoTraducido()
	{
		if (DataPersistenceManager.instance.interfaceDataText.tutorialesText.TryGetValue(IdiomaGlobalManager.instanciaIdioma.idiomaActual, out SerializableDictionary<string, string> secondDictionary))
		{
			if (secondDictionary.TryGetValue(idTutorialText, out string resultadoTraducido))
			{
				textoTutorial.text = resultadoTraducido;
				idiomaGuardado = IdiomaGlobalManager.instanciaIdioma.idiomaActual;
			}
		}
	}
}
