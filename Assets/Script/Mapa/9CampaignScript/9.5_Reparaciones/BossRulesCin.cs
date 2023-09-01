using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRulesCin : MonoBehaviour
{
    [Header ("Soldier Rules")]
    [SerializeField] SoldierLife asitenteLife;
    [SerializeField] SoldadoNormal asistente;
    [SerializeField] SoldierLife bossLife;
    [SerializeField] SoldadoNormal boss;
    [Header("Cinematics")]
    [SerializeField] FallCinematic fallCinematicAsistance;
    [SerializeField] GameObject rangeCar;
    void Update()
    {
        //Solo salta la cinemática si se cumple una condición especifica para ello en el caso del Asistente que se le caíga la lámpara,
        //mientras que al Boss le tiene que golpear la cabeza el coche
        ConditionsBossCin();
    }
    void ConditionsBossCin()
    {
        if(asitenteLife.vida <= 0 || bossLife.vida <= 0 ||
            asistente.berserker || boss.berserker)
        {
            Destroy(fallCinematicAsistance);
            Destroy(rangeCar);
        }
    }
}
