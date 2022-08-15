using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarBox : MonoBehaviour
{
    [SerializeField] PlatformState statusPlatform;
    [SerializeField] List<GameObject> boxCarga;


    float timeInCarga;
    public float timeInCargaLimite;

    int numBoxes;

    bool cargarBoxes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Cargar()
    {
        if (cargarBoxes)
        {
            timeInCarga += Time.deltaTime;
            //Start Charge
            if (timeInCarga >= timeInCargaLimite && numBoxes < boxCarga.Count)
            {
                boxCarga[numBoxes].SetActive(true);
                numBoxes++;
                timeInCarga = 0;
            }
            //Finish Charge
            else if (numBoxes >= boxCarga.Count)
            {
                timeInCarga = 0;
                cargarBoxes = false;
                statusPlatform.cargaPlatform = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) cargarBoxes = true;
    }
}
