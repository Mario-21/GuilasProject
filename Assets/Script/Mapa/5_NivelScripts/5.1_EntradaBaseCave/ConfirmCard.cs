using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmCard : MonoBehaviour
{
    public int indexMod;
    [SerializeField] OpenReforcedDoor reforcedDoor;
    [SerializeField] ActivarModificador confirm; //Separar Los activadores y pooner cada uno en su respectiva tarjeta
    [SerializeField] SpriteRenderer confirmButton;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) KeyUse();
    }

    // Update is called once per frame
    void Update()
    {
        ConfirmInsertCard();
    }
    void ConfirmInsertCard()
    {
        if (confirm.modificacion)
        {
            KeyUse();
        }
    }
    void KeyUse()
    {
        //Variable
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Feedback 
        confirmButton.color = Color.green;
        //Incrementar el numero de keys
        reforcedDoor.keys++;
        //Desactivar para no poder usar más una key aquí
        confirm.enabled = false;
        //Desactivar el mismo script para que no aumente la Key todo el rato
        this.enabled = false;
    }
}
