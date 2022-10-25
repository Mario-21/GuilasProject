using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCin : MonoBehaviour
{
    public int indexMod;
    public int spawn;
    public int sceneCin;

    ActivarModificador activador;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GoCinematicScene();
    }
    void GoCinematicScene()
    {
        if (activador.modificacion)
        {
            CheckPointController.numeroCheckPoint = spawn;
            EstructuraNiveles.nivel = sceneCin;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
