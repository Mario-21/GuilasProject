using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducto : MonoBehaviour
{
    [Header("Colocar Food")]
    [SerializeField] ColocarFood haveFood;
    [Header("Bell")]
    [SerializeField] TocarBell countBell;
    [Header("Food")]
    [SerializeField] GameObject food;

     Animator conductoAnim;
    void Start()
    {
        conductoAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TransportFood();
    }
    void TransportFood()
    {
        if (haveFood.ductoAction)
        {
            food.SetActive(true);
            countBell.soundBellCount = 0;
            haveFood.ductoAction = false;
            conductoAnim.SetBool("Abrir", true);
        }
    }
}
