using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReestablecerPosEnemy : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldado;
    [Tooltip("Solo puede ser entre 1 (derecha) y -1 (izquierda) ")]
    [Range(-1,1)]
    [SerializeField] int direccionSoldado;
    float timerScale;
    [SerializeField] float timerScaleLimit;
    public bool reestablecer;

    private void Update()
    {
        if (reestablecer && !soldado.berserker && !soldado.busquedaMode)
        {
            timerScale += Time.deltaTime;
            if(timerScale >= timerScaleLimit)
            {
                soldado.transform.localScale = new Vector3(direccionSoldado, 1f, 1f);
                timerScale = 0;
                reestablecer = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            reestablecer = true;
        }
    }
}
