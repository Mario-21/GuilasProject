using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteCodeDestornillador : MonoBehaviour
{
    public int codeNumber;

    public CodigoDestornillador codeDestornillador;

    Valvula valvulaAsignada;
    [SerializeField] BotonDrenaje systemDrain;

    int usosWriteCode;
    int writeCodeV2;
    private void Awake()
    {
        valvulaAsignada = GetComponent<Valvula>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(usosWriteCode < 1 && valvulaAsignada.valvulaOn)
        {
            WriteCode();
            Debug.Log("Camomila");
            usosWriteCode++;
        }
        //Es indiferente eso
        if(!valvulaAsignada.valvulaOn)
        {
            usosWriteCode = 0;
        }
        ConditionsRejillaOpen();
    }

    void WriteCode()
    {
        codeDestornillador.writeCodigoDestornillador += codeNumber.ToString();
    }
    void ConditionsRejillaOpen()
    {
        //Si la rejilla se encuentra abierta
        if (systemDrain.statusRejillas)
        {
            //Si aparece la cascada, significa que de alguna manera la has activado
            if (valvulaAsignada.cascada.activeInHierarchy)
            {
                if (writeCodeV2 < 1)
                {
                    WriteCode();
                    Debug.Log("La cascada ha aparecido");
                    writeCodeV2++; ;
                }
            }
            else
            {
                writeCodeV2 = 0;
            }
        }
    }
}
