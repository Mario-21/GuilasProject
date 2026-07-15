using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DestruirInstancias : MonoBehaviour
{
    public Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;

    void Start()
    {
        //Fetch the Image from the GameObject
       
    }

    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKey(KeyCode.K))
        {
            m_Image.sprite = m_Sprite;
        }
    }

}
