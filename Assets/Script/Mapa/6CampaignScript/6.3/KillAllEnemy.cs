using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemy : MonoBehaviour
{
    [Header("Condicion To Drop")]
    public int numSoldiers;
    [SerializeField] OnCinematic cinematic;
    [SerializeField] DespertarSoldiers wakeUpAll;
    [Header("Cinematic Data")]
    public int cinematicIndex;
    [Header("Item Data")]
    public int itemRecoger;
    public GameObject itemDrop;
    int limitSpawn;

    [HideInInspector] public List<GameObject> soldiersDeath;
    void Start()
    {
        if (SaveScene.instancia.listaItemsNivelGuardar[itemRecoger].objetoObtenido || StatusGameobjectsVariables.statusGameobject.modificacion[cinematicIndex].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SaveScene.instancia.listaItemsNivelGuardar[itemRecoger].objetoObtenido && !StatusGameobjectsVariables.statusGameobject.modificacion[cinematicIndex].modificacion) AllDeath();
    }
    void AllDeath()
    {
        if(numSoldiers <= 0 && limitSpawn < 1)
        {
            //when you kill all soldiers the last soldier transform change when you enter in the scene, because you cant establish the same order when they died,
            //so you register the LastPositionOfDeath only once 
            if(ExtraVariable.extras.onlyOne < 1)
            {
                ExtraVariable.extras.xLastDeath = soldiersDeath[soldiersDeath.Count - 1].transform.position.x;
                ExtraVariable.extras.yLastDeath = soldiersDeath[soldiersDeath.Count - 1].transform.position.y;
                ExtraVariable.extras.onlyOne++;
            }
            Debug.Log("Task Complete");
            cinematic.enabled = false;
            wakeUpAll.enabled = false;
            GameObject itemDropClon = Instantiate(itemDrop, new Vector3(ExtraVariable.extras.xLastDeath, ExtraVariable.extras.yLastDeath, 0), Quaternion.identity);
            limitSpawn++;

        }
    }
}
