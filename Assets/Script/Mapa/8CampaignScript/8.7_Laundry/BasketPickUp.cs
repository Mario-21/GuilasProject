using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPickUp : MonoBehaviour
{
    [SerializeField] CogerObjeto basketItem;
    [Header("Conditions Pick Basket")]
    [SerializeField] SoldierLife soldadoLaundry;
    public int indexAllergy;
    public int indexBath;
    //3 Condiciones
    //Si el soldado esta Muerto
    //Con Alergia o en el baño
    void Update()
    {
        CanPickBasket();
    }
    void CanPickBasket()
    {
        //Si el soldado esta Muerto
        //Con Alergia 
        //En el Baño
        if (soldadoLaundry.vida <= 0 
            || StatusGameobjectsVariables.statusGameobject.modificacion[indexAllergy].modificacion 
            || StatusGameobjectsVariables.statusGameobject.modificacion[indexBath].modificacion)
        {
            //Puedes coger el item
            basketItem.enabled = true;
        }
    }
}
