using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTutoGame : MonoBehaviour
{
    public int indexTuto;
    public GameObject tutoIndicado;
    BoxCollider2D colliderTuto;
    private void Awake()
    {
        colliderTuto = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexTuto].modificacion)
        {
            colliderTuto.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(TutoControlerInGame.tutoActual);
            //Llamar desde aqui a tu TutorialDeath, asi al morir sabe que variable debe colocar en verdadero.
            Instantiate(tutoIndicado);
            colliderTuto.enabled = false;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexTuto].modificacion = true;
            //Destroy(TutoControlerInGame.tutoActual);
        }
    }
}
