using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allergy : MonoBehaviour
{
    public int indexMod;
    [Header("Soldado Info")]
    [SerializeField] SoldierLife soldadoLaundry;
    //[SerializeField] SpriteRenderer headSoldadoLaundry;
    //Llamar animacion
    [SerializeField] GameObject cabezaNormal;
    [SerializeField] GameObject cabezaAlergia;
    //public Animator animAllergy;
    //public Color allergyColor;


    [Header("Allergy Time Activation")]
    [SerializeField] float allergyTimeOnLimit;
    float allergyTime;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            cabezaNormal.SetActive(false);
            cabezaAlergia.SetActive(true);
            this.enabled = false;
        }
    }
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if (allergyTime >= allergyTimeOnLimit)
            {
                AllergyOn();
            }
            else
            {
                allergyTime += Time.deltaTime;
            }
        }
    }
    void AllergyOn()
    {
        //animAllergy.enabled = true;
        cabezaNormal.SetActive(false);
        cabezaAlergia.SetActive(true);
        soldadoLaundry.Daño(3);
        this.enabled = false;
    }
}
