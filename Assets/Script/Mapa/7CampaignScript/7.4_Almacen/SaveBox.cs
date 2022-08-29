using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBox : MonoBehaviour
{
    public string saveBoxPassword;
    public string saveBoxPassword2;
    [SerializeField] Text textSaveBox;
    public int numTeclasPress;
    public int lastTecla;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (textSaveBox.text == saveBoxPassword.ToString()) Debug.Log("Falcom");

        saveBoxPassword2 = textSaveBox.text;

    }
    void SeePassword()
    {

    }
    public void DeleteNum()
    {

        textSaveBox.text.Replace(saveBoxPassword, "doner");
    }
    public void ColocarNum(int num)
    {
        textSaveBox.text += num;
        numTeclasPress++;
        //CUando borres la tecla hay que saber cual es la ultima de la ultima. si borras la segunda, luego borra la primera
        lastTecla = num;
    }
}
