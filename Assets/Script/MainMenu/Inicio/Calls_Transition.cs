using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calls_Transition
{
    public void Call(Animator anim, string nameAnimVar)
    {
        anim.SetTrigger(nameAnimVar);
    }
}
