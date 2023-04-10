using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHere))]
public class ScientificRoomOpen : MonoBehaviour
{
    public int indexMod;
    PlayerHere player;
    [Header("Feedback")]
    [Tooltip("Puedes establecer el feedback si quieres, simplemente cambia algo de rojo a verde")]
    public bool feedback;
    [SerializeField] SpriteRenderer botonFeedback;
    public Color colorFeedback = Color.green;   
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            if (feedback) botonFeedback.color = colorFeedback   ;
        }
    }
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) OpenScientificRoom();
    }
    void OpenScientificRoom()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                if (feedback) botonFeedback.color = colorFeedback;
            }
        }
    }
}
