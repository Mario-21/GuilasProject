using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTutoriales : MonoBehaviour
{
    public int indexMod;
    [Header("Escena Tutorial")]
    public int indexTutorial;
    public int scenaTutorial;
    [Header("Pausa")]
    public PauseMenu pause;

    BoxCollider2D boxTrigger;
    private void Awake()
    {
        boxTrigger = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            boxTrigger.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Coloca la variable para que no vuelva aparecer al volver a entrar en escena
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            //Desactiva el Collider para no poder volver a salir
            boxTrigger.enabled = false;
            //No puedes pasar la pausa
            pause.enabled = false;
            //Spawnea el tutorial
            SpawnTutoriales.spawnTutorial = indexTutorial;
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync(scenaTutorial, LoadSceneMode.Additive);
        }
    }
}
