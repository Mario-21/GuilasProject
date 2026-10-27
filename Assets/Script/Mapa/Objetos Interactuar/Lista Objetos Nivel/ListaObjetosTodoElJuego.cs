using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaObjetosTodoElJuego : MonoBehaviour
{
    public List<IDObjetosCompleta> dataObjetosJuego;

    [ContextMenu("Genera una ID aleatoria a todos los objetos de la Lista")]
    private void GenerarIDObjetos()
    {
        for(int i = 0; i < dataObjetosJuego.Count; i++)
        {
            dataObjetosJuego[i].IDObjeto = System.Guid.NewGuid().ToString();
            Debug.Log("El tamaño de la id es de " + dataObjetosJuego[i].IDObjeto.Length);
        }
    }

    
}


[System.Serializable]
public class IDObjetosCompleta
{
    public string nombreObjeto;
    public string IDObjeto;
}
