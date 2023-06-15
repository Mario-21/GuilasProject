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
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            notebook.sprite = notebookRevealPass;
            password.enabled = true;
        }
        activar = GetComponent<ActivarModificador>();
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        SeePapers();
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) SeePassword();
    }
    void SeePapers()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
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
    void SeePassword()
    {
        if (activar.modificacion) 
        {
            notebook.sprite = notebookRevealPass;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            password.enabled = true;
        }
    }
}
