using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePanelQuarry : MonoBehaviour
{
    public int indexMod;
    ActivarModificador activador;

    [SerializeField] UseQuarry ascensor;
    private void Awake()
    {
        activador = GetComponent<ActivarModificador>();
    }
    void Start()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ascensor.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnPanel();
    }
    void OnPanel()
    {
        if (activador.modificacion || StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ascensor.enabled = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
