using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHere))]
public class SeeCartel : MonoBehaviour
{
    PlayerHere player;
    [Header("Reveal Password")]
    public Image notebook;
    bool seeNote;
    Inventory inventario;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        inventario = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        SeeNotes();
    }
    void SeeNotes()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                seeNote = !seeNote;
                //Lo colocas en falso para que no se abra una vez salgas del cartel que estas viendo
                Inventory.gameIsPause = false;
                //Cierras el inventario por si has decidido ver el cartel con este abierto
                inventario.CloseInventory();
                //Inhabilitas para no poder abrir mientras ves el cartel
                inventario.enabled = !inventario.enabled;
            }
            if (seeNote)
            {
                notebook.gameObject.SetActive(true);
            }
            else
            {
                notebook.gameObject.SetActive(false);
            }

        }
        else
        {
            notebook.gameObject.SetActive(false);
            seeNote = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventario.enabled = true;
        }
    }
}
