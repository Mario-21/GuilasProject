using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoltarDialogo : MonoBehaviour
{
    public int indexMod;
    [Tooltip("Esta sección es para elegir si quieres que el dialogo modifique la variable del Index o no")]
    public bool indexOpcional;

    [SerializeField] bool enemigoDetectado;

    [Header("Datos Dialogo")]
    public GameObject globoDialogo;
    public Transform ubiGloboDialogoSpawn;
    public float timeDialogoLimite;
    int dialogoContador;
    [Header("Datos Escena")]
    public int returnScene;
    public string nombreSiguienteEscenaVolver;
    public int checkpoint;
    public float timeEscena;
    public float timeEscenaLimite;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion && indexOpcional) this.enabled = false;
    }
    void Update()
    {
        if (enemigoDetectado)
        {
            timeEscena += Time.deltaTime;
            if(timeEscena >= timeDialogoLimite)
            {
                SpawnearDialogo();
            }
            if(timeEscena >= timeEscenaLimite)
            {
                VolverEscena();
            }
        }
    }

    void SpawnearDialogo()
    {
        if (dialogoContador < 1)
        {
            Instantiate(globoDialogo, ubiGloboDialogoSpawn.position, Quaternion.identity);
            dialogoContador++;
        }
    }
    void VolverEscena()
    {
        if(indexOpcional)StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        CheckPointController.numeroCheckPoint = checkpoint;
        EstructuraNiveles.nivel = returnScene;
        EstructuraNiveles.nombreNivel = nombreSiguienteEscenaVolver;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemigoDetectado = true;
        }
    }
}
