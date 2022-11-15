using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMachine : MonoBehaviour
{
    public int indexMod;
    [Header("Machine")]
    [SerializeField] BoxCollider2D colliderMachine;
    [Header("Confirm")]
    [SerializeField] SpriteRenderer[] condirmMachine;

    ActivarModificador activador;
    int e;
    void Start()
    {
        activador = GetComponent<ActivarModificador>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            OnMachine();
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activador.modificacion) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            OnMachine();
        }
    }
    void OnMachine()
    {
        colliderMachine.enabled = true;

        while (e < condirmMachine.Length)
        {
            condirmMachine[e].color = Color.green;
            Debug.Log("Estenuar" + " " + e);
            e++;
        }
    }
}
