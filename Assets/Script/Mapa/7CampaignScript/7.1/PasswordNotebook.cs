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
    public Image notebook;
    public Text password;
    public Sprite notebookRevealPass;
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
            notebook.sprite = notebookRevealPass;
            password.enabled = true;
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
    void SeePassword()
    {
        if (activar.modificacion) 
        {
            notebook.sprite = notebookRevealPass;
            password.enabled = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
