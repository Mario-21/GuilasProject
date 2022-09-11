using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceLife_Death : MonoBehaviour
{
    public int exceedTime;
    public int minusTime;

    [SerializeField] SpriteRenderer headNovice;
    [SerializeField] Animator novice;
    public Color color;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[exceedTime].modificacion)
        {
            headNovice.color = color;
            novice.enabled = false;
        }
        else if (StatusGameobjectsVariables.statusGameobject.modificacion[minusTime].modificacion)
        {
            headNovice.color = Color.white;
         
        }
    }
}
