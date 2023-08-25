using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRecoveryRoom : MonoBehaviour
{
    public string nameSoldier;
    public int cinematicScene;
    [SerializeField] BloquearMovimientoPlayer playerBloq;
    [SerializeField] SoldadoNormal soldierNormal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == nameSoldier)
        {
            playerBloq.BloquearMovPlayer();
            EstructuraNiveles.nivel = cinematicScene;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            soldierNormal.enabled = false;
            soldierNormal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            soldierNormal.OutAnimation();
        }
        
    }
}