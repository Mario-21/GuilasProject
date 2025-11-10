using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillConditions : MonoBehaviour
{
    public int indexMod;
    [Header("Condiciones Totales")]
    [SerializeField] int actualConditionsOn;
    public int totalConditions;
    [SerializeField] List<int> conditionsDrill;
    [Header("Acción que quieres realizar")]
    public GameObject objetoAccion;
    public enum Acción
    {
        Aparecer,
        Desaparecer,
        Default
    }
    public Acción accionARealizar;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            AccionTrasFinalizarCondiciones();
        }
    }
    private void Update()
    {
        ConditionsCyclo();
    }
    void ConditionsCyclo()
    {
        for (int i = 0; i < conditionsDrill.Count; i++)
        {
            Debug.Log("Docenas de Listas");
            if (StatusGameobjectsVariables.statusGameobject.modificacion[conditionsDrill[i]].modificacion)
            {
                actualConditionsOn++;
                conditionsDrill.Remove(conditionsDrill[i]);
            }
        }
        if (actualConditionsOn >= totalConditions)
        {
            AccionTrasFinalizarCondiciones();
        }
    }
    void AccionTrasFinalizarCondiciones()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        switch (accionARealizar)
        {
            case Acción.Aparecer:
                objetoAccion.SetActive(true);
                break;
            case Acción.Desaparecer:
                objetoAccion.SetActive(false);
                break;
            case Acción.Default:
                break;
        }
        this.enabled = false;
    }
}
