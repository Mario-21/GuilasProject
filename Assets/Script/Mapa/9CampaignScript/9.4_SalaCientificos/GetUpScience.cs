using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpScience : MonoBehaviour
{
    public int indexMod;

    [SerializeField] List<SoldierLife> vidaSoldiers;
    void Start()
    {
        if(ExtraVariable.extras.actionOne >= 1)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Lo hago en el update porque establecerlo en el start hace que establezca esta antes que el ActualStatus (quien conserve la vida anterior), por tanto los soldados acabarían muertos
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion && ExtraVariable.extras.actionOne < 1)
        {
            GetUpScientific();
            ExtraVariable.extras.actionOne++;
        }
    }
    void GetUpScientific()
    {
        for (int i = 0; i < vidaSoldiers.Count; i++)
        {
            vidaSoldiers[i].vida = 1;
        }
    }
}
