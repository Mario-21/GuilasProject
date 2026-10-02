using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaCompuerta : MonoBehaviour
{
    public int indexMod;
    [Header("Info Drenajes")]
    public int indexDrenajePrincipal;
    public int indexDrenajeSecundario;
    [Header("Info Aguas")]
    public WaterData aguaPrincipal;
    public int aguaDataSecundaria;
    public int nuevoLimiteAgua;

	float alturaLimiteAgua;
    void Start()
    {
		LimitarAguaCalculo();
    }

    // Update is called once per frame
    void Update()
    {

		NuevoLimiteAguaYTraspaso();

		/*
		if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
		{
			return;
		}*/
		//Esta condicion dependerá del funcionamiento del drenaje, las válvulas y las rejillas.
		//No me acuerdo de como funciona realmente, si detecta primero el estado de la rejilla y ya ahí decide hacer algo o no; o en su defecto, siempre lo ejecuta,pero en cuanto detecta que la rejilla esta abierta
		//pasa a zero.
		//Esto es importante, dado que si existe un microsegundo donde aumenta estando la rejilla abierta, colocará automáticamente la variable en verdadero, cosa que no tendría sentido.
		//Repito, esto depende de como funcione.
		/*
		if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajePrincipal].modificacion)
		{
			//Si el agua supera al nuevo limite establecido
			if (ListWaters.listWaters.infoAguas[aguaDataPrincipal].porcentajeAgua >= nuevoLimiteAgua)
			{
				if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeSecundario].modificacion)
				{
					StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajePrincipal].modificacion = true;
					
				}
			}
		}*/
	}
	void NuevoLimiteAguaYTraspaso()
	{
		
		if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajePrincipal].modificacion) 
		{
			if (ListWaters.listWaters.infoAguas[aguaPrincipal.indexWater].porcentajeAgua > nuevoLimiteAgua)
			{
				ListWaters.listWaters.infoAguas[aguaPrincipal.indexWater].porcentajeAgua = nuevoLimiteAgua;
				aguaPrincipal.transform.position = new Vector3(aguaPrincipal.transform.position.x, alturaLimiteAgua, aguaPrincipal.transform.position.z);
				//Dependiendo de como interactue su boton de drenaje asignado, habrá que colocar esta condicion o no if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeSecundario].modificacion)
				ListWaters.listWaters.infoAguas[aguaDataSecundaria].porcentajeAgua = 100;
				//Coloca el index de aguaEstancada
				StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
			}
		}
	}
	void LimitarAguaCalculo()
	{
		float alturaWater = aguaPrincipal.alturaTotal * nuevoLimiteAgua / 100;
		alturaLimiteAgua = aguaPrincipal.alturaMin.position.y + alturaWater;
	}
}
