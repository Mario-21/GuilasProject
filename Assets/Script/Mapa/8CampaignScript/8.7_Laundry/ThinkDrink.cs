using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkDrink : MonoBehaviour
{
    [Header("Distance See Globo")]
    [SerializeField] SoldadoNormal soldado;
    [SerializeField] SoldierLife soldadoLife;
    [SerializeField] Transform player;
    [Tooltip("Distancia en la que aparecera el cuadro de diálogo")]
    public float distanceMax;
    [Header("Animation Globo")]
    public Animator thinkGlobo;
    [Header("Conditions to See")]
    public int indexAllergy;
    public int indexBath;

    bool canSeeThink;
    void Start()
    {
        canSeeThink = true;
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexAllergy].modificacion || StatusGameobjectsVariables.statusGameobject.modificacion[indexBath].modificacion)
        {
            this.enabled = false;
            thinkGlobo.SetBool("ThinkSee", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSeeThink) SeeThink();

        if(soldadoLife.vida <= 0 || soldado.berserker)
        {
            canSeeThink = false;
            thinkGlobo.SetBool("ThinkSee", false);
            this.enabled = false;
        }
    }
    void SeeThink()
    {
        if(DistancePlayerSoldado().magnitude < distanceMax)
        {
            thinkGlobo.SetBool("ThinkSee", true);
        }
        else
        {
            thinkGlobo.SetBool("ThinkSee", false);
        }
    }
    Vector2 DistancePlayerSoldado()
    {
        Vector2 distance;

        return distance = player.position - soldado.transform.position;
    }
}
