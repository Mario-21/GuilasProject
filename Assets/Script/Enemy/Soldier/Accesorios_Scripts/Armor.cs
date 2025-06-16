using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldado;
    Animator armorAnim;
    void Start()
    {
        armorAnim = GetComponent<Animator>();
    }
    void Update()
    {
        CaminarArmor();
    }
    void CaminarArmor()
    {
        if (soldado.movimiento)
        {
            armorAnim.SetBool("Caminar_Armor", true);
        }
        else
        {
            armorAnim.SetBool("Caminar_Armor", false);
        }
    }
}
