using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReviveTurnos : MonoBehaviour
{
    public ReviveTurnos reviveTurnos;
    void Start()
    {
        if (reviveTurnos == null)
        {
            reviveTurnos = FindObjectOfType<ReviveTurnos>();
        }
    }

    public void TurnosReviveButton()
    {
        if (reviveTurnos != null)
        {
            reviveTurnos.TurnosRevivir();
        }
    }
}
