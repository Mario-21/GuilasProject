using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCodeDestornillador : MonoBehaviour
{
    [SerializeField] CodigoDestornillador codeDestornillador;
    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                codeDestornillador.writeCodigoDestornillador = "";
            }
        }
    }
}
