using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHere))]
public class ScientificRoomOpen : MonoBehaviour
{
    public int indexMod;
    [Header("Feedback")]
    [Tooltip("Puedes establecer el feedback si quieres, simplemente cambia algo de rojo a verde")]
    public bool feedback;
    [SerializeField] SpriteRenderer botonFeedback;
    public Color colorFeedback = Color.green;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            if (feedback) botonFeedback.color = colorFeedback;
            this.enabled = false;
        }
    }
    public void OpenScientificRoom()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        Debug.Log("Presionaste la puerta science");
        if (feedback) botonFeedback.color = colorFeedback;
    }
}
