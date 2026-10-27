using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveSoldier : MonoBehaviour
{
    public int indexMod;

    ActivarModificador activador;
    [Header("Detectar_Echar Enabled")]
    [SerializeField] BoxCollider2D detectar_Echar;
    [SerializeField] SpriteRenderer señalD_E;
    [Header("Soldado Conditions")]
    [SerializeField] SoldadoNormal soldado;
    [SerializeField] SoldierLife soldadoLife;
    [Header("Complete Task")]
    [SerializeField] ThinkDrink thinkMeat;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            GiveMeatBall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion)
        {
            GiveMeatBall();
        }
        else if(soldado.berserker || soldadoLife.vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void GiveMeatBall()
    {
        detectar_Echar.enabled = false;
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Desactivas el Objeto para no poder realizar la accion dos veces, en caso de que el objeto tenga más de un uso
        this.gameObject.SetActive(false);
        //Señalas de alguna manera que ya puedes pasar a la sala
        señalD_E.color = Color.red;
        //Desactivas el dialogo
        thinkMeat.enabled = false;
        thinkMeat.thinkGlobo.SetBool("ThinkSee", false);
    }
}
