using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnListasProbarNivel : MonoBehaviour
{
    public GameObject dataPlayerList;
    public GameObject listItemsLevel;
    public GameObject listObjective;
    private void Awake()
    {
        Instantiate(dataPlayerList);
        Instantiate(listItemsLevel);
        Instantiate(listObjective);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
