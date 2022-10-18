using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRulesCin : MonoBehaviour
{
    [Header("Items Variables Rules")]
    public int indexBoss;
    public int indexAsistente;
    [Header ("Soldier Rules")]
    [SerializeField] SoldierLife asitente;
    [SerializeField] SoldierLife boss;
    [Header("Cinematics")]
    [SerializeField] FallCinematic fallCinematicAsistance;
    [SerializeField] FallCinematic fallCinematicBoss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Solo salta la cinemática si se cumple una condición especifica para ello en el caso del Asistente que se le caíga la lámpara,
        //mientras que al Boss le tiene que golpear la cabeza el coche
        ConditionsBossCin();
    }
    void ConditionsBossCin()
    {
        if(asitente.vida <= 0 || boss.vida <= 0 ||
           StatusGameobjectsVariables.statusGameobject.modificacion[indexBoss].modificacion ||
           StatusGameobjectsVariables.statusGameobject.modificacion[indexAsistente].modificacion)
        {
            Destroy(fallCinematicAsistance);
            Destroy(fallCinematicBoss);
        }
    }
}
