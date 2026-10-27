using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLadoSpawn : MonoBehaviour
{
    public List<GameObject> delete;
    public List<GameObject> show;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Show_Delete_Items showAndDelete = new Show_Delete_Items();
            showAndDelete.DeleteItems(delete);
            showAndDelete.ShowItems(show);
        }
    }
}
