using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHere))]
public class SeeCartel : MonoBehaviour
{
    PlayerHere player;
    [Header("Reveal Password")]
    public Image notebook;
    bool seeNote;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        SeeNotes();
    }
    void SeeNotes()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                seeNote = !seeNote;
            }
            if (seeNote)
            {
                notebook.gameObject.SetActive(true);
            }
            else
            {
                notebook.gameObject.SetActive(false);
            }

        }
        else
        {
            notebook.gameObject.SetActive(false);
            seeNote = false;
        }
    }
}
