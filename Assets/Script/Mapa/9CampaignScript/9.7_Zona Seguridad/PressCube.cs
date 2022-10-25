using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressCube : MonoBehaviour
{
    [SerializeField] CuboLamentos cubeLamentos;
    [SerializeField] Image botonIcon;
    Button boton;
    Image botonImage;
    void Start()
    {
        boton = GetComponent<Button>();
        botonImage = GetComponent<Image>();
    }

    void Update()
    {
        if (!cubeLamentos.inCubo)
        {
            Debug.Log("Cometa");
            botonImage.color = new Color(1f, 1f, 1f, 1f);
            botonIcon.color = new Color(1f, 1f, 1f, 1f);
            boton.enabled = true;
        }
    }
    public void ColocarPassword(int number)
    {
        cubeLamentos.passwordComplete += number.ToString();
        botonImage.color = new Color(1f, 1f, 1f, 0.25f);
        botonIcon.color = new Color(1f, 1f, 1f, 0.5f);
        boton.enabled = false;
    }

    
}
