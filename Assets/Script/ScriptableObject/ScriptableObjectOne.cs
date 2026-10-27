using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Enemigo Dato", menuName = "Enemigo Dato")]
public class ScriptableObjectOne : ScriptableObject
{
    [SerializeField] private string nombreEnemigo;
    [SerializeField] private int vida;
    [SerializeField] private bool muerto;
    [SerializeField] private bool berserker;
    [SerializeField] private int nivelMuerte;
    public List<ListaModificaciones> variablesNivel;

    public string NombreEnemigo { get { return nombreEnemigo; } }
    public int VidaEnemigo { get { return vida; } }
    public bool MuerteEnemigo { get { return muerto; } }
    public bool EstadoEnemigo { get { return berserker; } }
    public int EscenaMuerteEnemigo { get { return nivelMuerte; } }

}
