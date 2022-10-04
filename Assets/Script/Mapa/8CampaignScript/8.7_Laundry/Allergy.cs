using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allergy : MonoBehaviour
{
    public int indexMod;
    [Header("Soldado Info")]
    [SerializeField] SoldierLife soldadoLaundry;
    [SerializeField] SpriteRenderer headSoldadoLaundry;
    public Color allergyColor;
    
    void Update()
    {
        AllergyOn();
    }
    void AllergyOn()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            headSoldadoLaundry.color = allergyColor;
            soldadoLaundry.Daño(10);
            this.enabled = false;

        }
    }
}
