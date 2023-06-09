using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillConditions : MonoBehaviour
{
    [SerializeField] int actualConditionsOn;
    public int totalConditions;
    [SerializeField] List<int> conditionsDrill;
    [Header("Success Conditions")]
    [SerializeField] GameObject success;
    [SerializeField] GameObject oldItem;
    private void Start()
    {
        ConditionsCyclo();
    }
    private void Update()
    {
        ConditionsCyclo();
    }
    void ConditionsCyclo()
    {
        for (int i = 0; i < conditionsDrill.Count; i++)
        {
            if (StatusGameobjectsVariables.statusGameobject.modificacion[conditionsDrill[i]].modificacion)
            {
                actualConditionsOn++;
                conditionsDrill.Remove(conditionsDrill[i]);
            }
        }
        if (actualConditionsOn >= totalConditions)
        {
            success.SetActive(true);
            oldItem.SetActive(false);
            this.enabled = false;
        }
    }
}
