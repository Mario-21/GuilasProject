using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allergy_Or_Bath : MonoBehaviour
{
    [Header("Allergy")]
    public int indexModAllergy;
    [SerializeField] UseAllergyButton allergyLimit;
    [Header("Bath")]
    public int indexModBath;
    [SerializeField] ParticleSystem beberEffect;
    [Header("Change Vaso")]
    public SaveButton buttonJarraLlena;
    public int vasoLleno;
    public SaveButton buttonJarraVacia;
    public int vasoVacio;
    [Header("Liquid")]
    [SerializeField] LiquidColor typeDrink;
    ActivarModificador activador;
    int once;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexModBath].modificacion || StatusGameobjectsVariables.statusGameobject.modificacion[indexModAllergy].modificacion)
        {
            this.enabled = false;
        }
    }
    void Update()
    {
        Drink();
    }
    void Drink()
    {
        if (activador.modificacion && once < 1)
        {
            if (typeDrink.selectedDrink == 1 || typeDrink.selectedDrink == 2)
            {
                SaveScene.instancia.consumption++;
                beberEffect.Play();
                once++;
                ChangeGlass();
                Bath();
            }
            if(typeDrink.selectedDrink == 0)
            {
                AllergyDrink();
                allergyLimit.LimitUse();
                buttonJarraLlena.LimitarUsos();
                once++;
                this.enabled = false;
            }
        }
        
    }
    void Bath()
    {
        if(SaveScene.instancia.consumption >= 3) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModBath].modificacion = true;
            this.enabled = false;
        }
    }
    void AllergyDrink()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexModAllergy].modificacion = true;
    }
    void ChangeGlass()
    {
        //Usas el vaso lleno y por tanto se vacia
        SaveScene.instancia.listaItemsNivelGuardar[vasoVacio].objetoObtenido = true;
        buttonJarraVacia.gameObject.SetActive(true);
        buttonJarraVacia.CallButtonAppear();

        SaveScene.instancia.listaItemsNivelGuardar[vasoLleno].objetoObtenido = false;
        buttonJarraLlena.gameObject.SetActive(false);
    }
}
