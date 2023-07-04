using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void CompleteObjectiveButton(GameObject objectiveButton)
    {
        objectiveButton.SetActive(true);
    }
}
