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
    private void Awake()
    {
        activador = GetComponent<ActivarModificador>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            drink.color = poison;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Show_Delete_Items show = new Show_Delete_Items();
        if (activador.modificacion && soldadoVida.vida > 0)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            show.DeleteItems(itemsDelete);
            show.ShowItems(itemsShow);
            drink.color = poison;
            //this.enabled = false;
        }
        //si el soldado muere posteriormente de echar el veneno, se restablecera a su estado original
        if(soldadoVida.vida <= 0)
        {
            show.DeleteItems(itemsShow);
            show.ShowItems(itemsDelete);
            this.enabled = false;
        }
    }
}
