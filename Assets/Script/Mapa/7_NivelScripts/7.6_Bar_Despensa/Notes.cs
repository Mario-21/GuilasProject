using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
public class Notes : MonoBehaviour
{
    PlayerHere player;
    bool readNote;
    public Image note;
    [Header("SFX Notes")]
    [SerializeField] EventReference noteSound;
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
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(noteSound);
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
