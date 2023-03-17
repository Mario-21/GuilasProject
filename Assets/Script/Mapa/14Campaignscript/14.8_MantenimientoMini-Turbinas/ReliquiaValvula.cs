using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliquiaValvula : MonoBehaviour
{
    public int indexMod;
    [Header("Valvula Data")]
    [SerializeField] Valvula valvula;
    public int limitUses;
    public int uses;
    public bool canIncrease;

    PlayerHere player;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        uses = ExtraVariable.extras.actionOne;
    }

    // Update is called once per frame
    void Update()
    {
        LimitUses();
        ExtraVariable.extras.actionOne = uses;
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z) && !valvula.valvulaOn && !canIncrease)
            {
                canIncrease = true;
                if(uses < limitUses) uses++;
            }
        }
    }
    void LimitUses()
    {
        if(uses >= limitUses)
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
        ExtraVariable.extras.actionOne = uses;
    }
}
