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
    [Header("Activate ScientificRoom")]
    public bool scienceRoom;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            if (feedback) botonFeedback.color = colorFeedback;
            this.enabled = false;
        }
    }
    void FixedUpdate()
    {
        //if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) OpenScientificRoom();
        //OpenScientificRoom();
    }
    private void Update()
    {
        OpenScientificRoom();
        if (scienceRoom) 
        {
            Debug.Log("Golondrina sefarea");
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
    void OpenScientificRoom()
    {
        if (player.playerImHere)
        {
            Debug.Log("ESToy en la puerta science");
            if (Input.GetButton("Action"))
            {
                scienceRoom = true;
                Debug.Log("Presionaste la puerta science");
                if (feedback) botonFeedback.color = colorFeedback;
            }
        }
    }
}
