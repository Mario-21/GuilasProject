using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstablecerTutoriales : MonoBehaviour
{

	public List<TutoInfo> tutorialesNivelEstablecer;

	bool establecerTuto = true;


	private void Start()
	{
		for (int i = 0; i < tutorialesNivelEstablecer.Count; i++)
		{
			//Primero revisas si premiamente se ha guardado en la data, si ya se ha guardado no hara nada, si NO lo ha guardado ahora lo sustituira para que en un futuro lo haga.
			GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(tutorialesNivelEstablecer[i].idTuto, out tutorialesNivelEstablecer[i].tutoDesbloqueado);

			if (!tutorialesNivelEstablecer[i].tutoDesbloqueado)
			{
				if (GameDataNoDestroy.instance.gameData.tutorialesCollected.ContainsKey(tutorialesNivelEstablecer[i].idTuto))
				{
					GameDataNoDestroy.instance.gameData.tutorialesCollected.Remove(tutorialesNivelEstablecer[i].idTuto);
				}
				GameDataNoDestroy.instance.gameData.tutorialesCollected.Add(tutorialesNivelEstablecer[i].idTuto, establecerTuto);
			}
		}

	}
}
