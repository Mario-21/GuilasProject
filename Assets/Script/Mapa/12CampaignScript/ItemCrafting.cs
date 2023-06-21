using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrafting : MonoBehaviour
{
    [Tooltip("Representa la variable de colocar el item en la mesa")]
    public int myIndexItem;
    [Tooltip("Representa la variable del crafteo de ambos objetos")]
    public int indexModCrafteo;

    ActivarModificador activador;

    //Item Mesa
    SpriteRenderer itemTable;
    [Header("Mesa Crafteo")]
    [SerializeField] CraftingTable itemCount;
    private void Awake()
    {
        itemTable = GetComponent<SpriteRenderer>();
        activador = GetComponent<ActivarModificador>();
    }
    void Start()
    {
        //SI has colocado el objeto en la mesa y todavia no has crafteado, aparece aun en la mesa
        if(StatusGameobjectsVariables.statusGameobject.modificacion[myIndexItem].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexModCrafteo].modificacion)
        {
            ShowItemToCraft();
        }
    }

    void Update()
    {
        if (activador.modificacion) 
        {
            itemCount.countItemCrafteo++;
            ShowItemToCraft();
            //Al colocar un item aumenta en uno el conteo de items para marcar que ya has usado este item.
        }
    }
    void ShowItemToCraft()
    {
        //Ves el item colocado en la mesa
        itemTable.enabled = true;

        StatusGameobjectsVariables.statusGameobject.modificacion[myIndexItem].modificacion = true;
        this.enabled = false;
    }
}
