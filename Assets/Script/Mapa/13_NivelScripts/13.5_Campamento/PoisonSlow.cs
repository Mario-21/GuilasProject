using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSlow : MonoBehaviour
{
    public int indexMod;
    [Header("Soldier Data")]
    [SerializeField] SoldierLife soldadoVida;
    [Header("Color Poison")]
    public SpriteRenderer drink;
    public Color poison;
    [Header("Items Show")]
    public List<GameObject> itemsShow;
    [Header("Items Delete")]
    public List<GameObject> itemsDelete;

    ActivarModificador activador;

    Show_Delete_Items show;
    private void Awake()
    {
        activador = GetComponent<ActivarModificador>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            drink.color = poison;
            activador.enabled = false;
            this.enabled = false;
        }
        show = new Show_Delete_Items();
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion)
        {
            //Si uso el veneno en la bebida esta  cambiará de color, además de activar la variable
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            drink.color = poison;
            //Si el soldado esta vivo, puede dar pie a la cinemática.
            if(soldadoVida.vida > 0)
            {
                activador.enabled = false;
                show.DeleteItems(itemsDelete);
                show.ShowItems(itemsShow);
            }
        }
        //si el soldado muere posteriormente de echar el veneno, se restablecera a su estado original
        if(soldadoVida.vida <= 0)
        {
            show.DeleteItems(itemsShow);
            show.ShowItems(itemsDelete);
            if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
        }
    }
}
