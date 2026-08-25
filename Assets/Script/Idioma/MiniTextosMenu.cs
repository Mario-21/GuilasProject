using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTextosMenu : MonoBehaviour
{
    public string idTextoMinus;
    Text textoPrincipal;
    string idiomaGuardado;
    // Start is called before the first frame update
    void Start()
    {
        textoPrincipal = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        IdiomaGlobalManager.instanciaIdioma.EstablecerTextosIdiomas(DataPersistenceManager.instance.interfaceDataText.interfaceText, idTextoMinus, textoPrincipal, ref idiomaGuardado);
        /*
        if (P1)
        {
            if (DataPersistenceManager.instance.interfaceDataText.interfaceText.TryGetValue(IdiomaGlobalManager.instanciaIdioma.idiomaActual, out SerializableDictionary<string, string> secondDictionary))
            {
                if (secondDictionary.TryGetValue(idTextoMinus, out string resultadoTraducido))
                {
                    textoPrincipal.text = resultadoTraducido;
                }
            }
        }
        if (P2)
        {
            if (GameDataNoDestroy.instance.gameData.minusText.TryGetValue(idTextoMinus, out SerializableDictionary<string, string> segundoDictionary))
            {
                if (segundoDictionary.TryGetValue(IdiomaGlobalManager.instanciaIdioma.idiomaActual, out string resultadoTraducido))
                {
                    textoPrincipal.text = resultadoTraducido;
                }
            }
        }
        */
    }
}
