using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PalancaMantenimiento))]
public class PalancaPuzzle : MonoBehaviour
{
    public int indexMod;

    [Header("Número Contraseña")]
    [SerializeField] int numCodigo;

    [SerializeField] AdminPalancaPuzzle adminPalancaPuzle;

    [HideInInspector] public PalancaMantenimiento palancaMant;

    private void Awake()
    {
        palancaMant = GetComponent<PalancaMantenimiento>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            adminPalancaPuzle.codigoString += numCodigo.ToString();
            ClotheData.clotheInfo.numCloth  = int.Parse(adminPalancaPuzle.codigoString);
            adminPalancaPuzle.digitosClotheData++;
            this.enabled = false;
        }
        //No se si debería meter aquí que 
    }
}
