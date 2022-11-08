using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFumarNoEnemy : MonoBehaviour
{
    public int indexMod;

    [Header("Enemy")]
    [SerializeField] SoldierLife enemyLife;

    [Header("Player Mask")]
    [SerializeField] PutGasMask colocarCigarro;
    [SerializeField] PutGasMask encenderCigarro;

    [Header("Use Cinematic")]
    [SerializeField] UseCin cinematicAspersor;

    bool fumarAreaNoEnemy;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyLife.vida <= 0)
        {
            ConditionsCinematicFumar();
        }
        
    }
    void ConditionsCinematicFumar()
    {
        //Tienes que entrar en la sala ya fumando 
        if (colocarCigarro.putMask && encenderCigarro.putMask && fumarAreaNoEnemy)
        {
            cinematicAspersor.UseCinematic();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        Debug.Log("Garma");
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fumarAreaNoEnemy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fumarAreaNoEnemy = false;
        }
    }
}
