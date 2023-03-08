using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletarNivel : MonoBehaviour
{
    public int siguienteNivel;
    [SerializeField] BloquearMovimientoPlayer blockPlayer;
    EstructuraNiveles anim = new EstructuraNiveles();

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blockPlayer.BloquearMovPlayer();
            EstructuraNiveles.nivel = siguienteNivel;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            CheckPointController.numeroCheckPoint = 0;

            //Destruye las listas del nivel
            for(int e = 0; e < ListDestroyEndLevel.levelList.levelListDestroy.Count; e++)
            {
                Destroy(ListDestroyEndLevel.levelList.levelListDestroy[e].gameObject);
                Debug.Log("La Lista " + ListDestroyEndLevel.levelList.levelListDestroy[e].name + " ha sido eliminada");
                
            }
            Destroy(ListDestroyEndLevel.levelList.gameObject);
        }

    }
}
