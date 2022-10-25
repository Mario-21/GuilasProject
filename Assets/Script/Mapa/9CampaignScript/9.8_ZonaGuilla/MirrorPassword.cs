using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPassword : MonoBehaviour
{
    public int uiItem;
    public GameObject uiNote;
    ActivarModificador activador;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion) PasswordWithMirror();
    }
    void PasswordWithMirror()
    {
        ListaItemsUI.listaItemsUI.listaAllItemUI[uiItem].itemUICatch = true;
        uiNote.SetActive(true);
    }
}
