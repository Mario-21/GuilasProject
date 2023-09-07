using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutGasMask : MonoBehaviour
{
    public GameObject gas_Mask;
    [SerializeField] SaveButton mascaraButton;
    public string tagName = "Mascara";
    bool canPut;
    public bool putMask;

    void Update()
    {
        CanUseMask();
        OffMask();
    }
    void CanUseMask()
    {
        if (canPut)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.takeClothes);
                putMask = true;
                PutMask();
            }
        }
    }
    void PutMask()
    {
        if (putMask)
        {
            gas_Mask.SetActive(true);
            mascaraButton.UsosGastados();
        }
    }
    void OffMask()
    {
        //NOTA: En el casco minero del nivel 5 te va habilitar ambos botones
        //Si llevo el cosmetico
        if (putMask)
        {
            //Pulso la te para quitarmelo
            if (Input.GetButtonDown("Take_Off"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.takeOffClothes);
                gas_Mask.SetActive(false);
                mascaraButton.HabilitarUsos();
                putMask = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) canPut = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) canPut = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName)) canPut = false;
    }
}
