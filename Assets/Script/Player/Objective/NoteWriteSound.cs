using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteWriteSound : MonoBehaviour
{
    public void NoteWrite()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.writeNote_UI);
    }
}
