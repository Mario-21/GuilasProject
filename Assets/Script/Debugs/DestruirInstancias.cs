using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class DestruirInstancias : MonoBehaviour
{
    public string IDObjetivos;
    public int indexObjetivos;

    private void Update()
    { 

    }
    [ContextMenu("Aumento Index")]
    void IncreaseObjetivos()
    {
        indexObjetivos++;
    }
}
