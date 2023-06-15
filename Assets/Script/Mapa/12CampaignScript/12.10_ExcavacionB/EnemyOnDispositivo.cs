using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnDispositivo : MonoBehaviour
{
    public int indexModEnemy;
    DispositivoElectrico device;
    void Start()
    {
        device = GetComponent<DispositivoElectrico>();
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexModEnemy].modificacion)
        {
            this.enabled = false;
        }
        if (device.luzOn)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModEnemy].modificacion = true;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !StatusGameobjectsVariables.statusGameobject.modificacion[indexModEnemy].modificacion)
        {
            //Enemigo encendera el dispositivo manualmente
            device.luzOn = true;
            //Calcula el gasto Electrico
            TipoDispositivo dispositivo = new TipoDispositivo();
            dispositivo.GastoElectrico(ref TurnosWorked.extras.valorGenerador, device.gastoElectrico, ref device.luzOn);
            //Variable para desactivar este trigger ya que solo quieres hacerlo una única vez
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModEnemy].modificacion = true;
            //Deja encendido el dispositivo en concreto
            StatusGameobjectsVariables.statusGameobject.modificacion[device.indexMod].modificacion = true;
            //Desactiva Script
            this.enabled = false;
        }
    }
}
