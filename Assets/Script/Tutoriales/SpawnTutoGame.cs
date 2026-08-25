using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class SpawnTutoGame : MonoBehaviour
{

    public string idTutorial;
    [Header("Info Tutorial")]
    public int indexTuto;
    public GameObject tutoIndicado;
    BoxCollider2D colliderTuto;
    private void Awake()
    {
        colliderTuto = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        //Primero revisamos si ya se ha dado desbloqueado el tutorial o no ---------> Ya no hace falta
        //GameDataNoDestroy.instance.gameData.tutorialesCollected.TryGetValue(idTutorial, out ControlerTutoriales.instanciaTutoriales.infoTutoNivel[indexTuto].tutoDesbloqueado);
        /*
        if (ControlerTutoriales.instanciaTutoriales.infoTutoNivel[indexTuto].tutoDesbloqueado)
        {
            colliderTuto.enabled = false;
        }
        */
        for(int i = 0; i < ControlerTutoriales.instanciaTutoriales.infoTutoNivel.Count; i++)
        {
            if(ControlerTutoriales.instanciaTutoriales.infoTutoNivel[i].idTuto == idTutorial)
            {
                if (ControlerTutoriales.instanciaTutoriales.infoTutoNivel[i].tutoDesbloqueado)
                {
                    colliderTuto.enabled = false;
                    break;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El player ha entradeo al tutorial");
            //Llamar desde aqui a tu TutorialDeath, asi al morir sabe que variable debe colocar en verdadero.
            //Instantiate(tutoIndicado);
            ControlerTutoriales.instanciaTutoriales.colaTutoriales.Enqueue(tutoIndicado);

            //Establecer variable
            ControlerTutoriales.instanciaTutoriales.infoTutoNivel[indexTuto].tutoDesbloqueado = true;

            //Cambia el estado del tutorial para que se desbloqueé
            if (GameDataNoDestroy.instance.gameData.tutorialesCollected.ContainsKey(idTutorial))
            {
                GameDataNoDestroy.instance.gameData.tutorialesCollected.Remove(idTutorial);
            }
            GameDataNoDestroy.instance.gameData.tutorialesCollected.Add(idTutorial, ControlerTutoriales.instanciaTutoriales.infoTutoNivel[indexTuto].tutoDesbloqueado);

            //Desactivar Collider para que no lo vuelva hacer
            colliderTuto.enabled = false;
            //StatusGameobjectsVariables.statusGameobject.modificacion[indexTuto].modificacion = true;
            //Destroy(TutoControlerInGame.tutoActual);
        }
    }
}
