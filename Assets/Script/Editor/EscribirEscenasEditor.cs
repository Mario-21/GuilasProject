using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(EscribirEscenas))]
public class EscribirEscenasEditor : Editor
{
    public override void OnInspectorGUI()
    {
        

        EscribirEscenas miEscribirEscenas = (EscribirEscenas)target;

        GUILayout.Space(10); // Espacio visual

        // Crea el botón en el Inspector
        if (GUILayout.Button("¡ReEscribir Escenas!"))
        {
            miEscribirEscenas.AlmacenarEstructurasNiveles();
        }

        // Dibuja los campos normales del inspector
        DrawDefaultInspector();
    }
}

