using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordNotebook : MonoBehaviour
{
    PlayerHere player;
    ActivarModificador activar;
    public int indexMod;
    [Header("Reveal Password")]
    public GameObject notebook;
    public GameObject notebookRevealPass;
    bool seeNote;
    private void Awake()
    {
        activar = GetComponent<ActivarModificador>();
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            notebookRevealPass.SetActive(true);
        }
    }
    void Update()
    {
        SeePapers();
        SeePassword();
    }
    void SeePapers()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.seeNote);
                seeNote = !seeNote;
            }
            if (seeNote)
            {
                notebook.SetActive(true);
            }
            else
            {
                notebook.SetActive(false);
            }
            
        }
        else
        {
            notebook.SetActive(false);
            seeNote = false;
        }
    }
    void SeePassword()
    {
        if (activar.modificacion) 
        {
            notebookRevealPass.SetActive(true);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
