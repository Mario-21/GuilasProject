using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLoop : MonoBehaviour
{
    [SerializeField] GameObject loopArea;
    [SerializeField] GameObject normalRoad;

    // Update is called once per frame
    void Update()
    {
        End_Loop();
    }
    void End_Loop()
    {
        if (ExtraVariable.extras.finalLoop)
        {
            loopArea.SetActive(false);
            normalRoad.SetActive(true);
        }
    }
}
