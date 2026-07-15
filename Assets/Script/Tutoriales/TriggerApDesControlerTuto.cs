using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerApDesControlerTuto : MonoBehaviour
{
	[Tooltip("Esto solo se suele usar en cambio de escenas a los que les sigue una cinemática")]
	[Header("Define que quieres hacer con el ControlerTutoriales")]
	public bool aparecer;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			//No se puede dar la condición del Contador de queue porque puede ocasionar que al entrar no tengas ninguna y quede desactivado, lo
			//que provocaría que ningun tutorial apareciese hasta que pases otra vez por el trigger.
			if (aparecer)
			{
				ControlerTutoriales.instanciaTutoriales.gameObject.SetActive(true);
			}
			else
			{
				ControlerTutoriales.instanciaTutoriales.gameObject.SetActive(false);
			}
		}
	}
}
