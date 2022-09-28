using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Notes : MonoBehaviour
{
    PlayerHere player;
    bool readNote;
    public Image note;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        ReadNote();
    }
    void ReadNote()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                readNote = !readNote;
            }
            if (readNote)
            {
                note.gameObject.SetActive(true);
            }
            else
            {
                note.gameObject.SetActive(false);
            }

        }
        else
        {
            note.gameObject.SetActive(false);
            readNote = false;
        }
    }
}
