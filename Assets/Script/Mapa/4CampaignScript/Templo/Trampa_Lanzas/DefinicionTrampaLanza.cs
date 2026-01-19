using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinicionTrampaLanza : MonoBehaviour
{
    [SerializeField] EscaleraTrampaLanza escaleraTrampaLanza;
    public TrampaLanzas trampaLanza;
    public bool lanzaActivaEscalera;
    public int onceExecution;
    void Start()
    {
        trampaLanza = GetComponent<TrampaLanzas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trampaLanza.posOrigen && onceExecution < 1)
        {
            escaleraTrampaLanza.CheckearLanzas();
            onceExecution++;
        }
        else if (!trampaLanza.posOrigen)
        {
            onceExecution = 0;
            lanzaActivaEscalera = false;
        }
    }
}
