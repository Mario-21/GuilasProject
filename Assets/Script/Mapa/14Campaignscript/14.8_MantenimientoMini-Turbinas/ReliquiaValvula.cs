using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliquiaValvula : MonoBehaviour
{
    public int indexMod;
    [Header("Valvula Data")]
    [SerializeField] Valvula valvula;
    public int limitUses;
    public bool canIncrease;

    PlayerHere player;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LimitUses();
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action") && !valvula.valvulaOn && !canIncrease)
            {
                canIncrease = true;
                if(ClotheData.clotheInfo.numCloth < limitUses) ClotheData.clotheInfo.numCloth++;
            }
        }
    }
    void LimitUses()
    {
        if(ClotheData.clotheInfo.numCloth >= limitUses)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        if(valvula.timeValvula >= valvula.timeLimitValvula)
        {
            canIncrease = false;
        }
    }
    private void OnDestroy()
    {
        //ExtraVariable.extras.actionOne = uses;
    }
}
