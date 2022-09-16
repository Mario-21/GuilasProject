using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int indexMod;
    [Header("Ghost Info")]
    public GameObject ghost;
    public float timeGhostLimit;
    public float timeGhost;
    bool ghostOn;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) Fantasma();
        else 
        {
            this.enabled = false;
        }
    }
    void Fantasma()
    {
        if (ghostOn)
        {
            timeGhost += Time.deltaTime;
            if (timeGhost >= timeGhostLimit)
            {
                ghostOn = false;
                ghost.SetActive(false);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pantalla"))
        {
            ghostOn = true;
        }
    }
}
