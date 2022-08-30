using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBox : MonoBehaviour
{
    public int indexMod;
    [Header("Password")]
    public string saveBoxPassword;
    int numTeclasPress;
    [Header("SaveBox UI")]
    [SerializeField] Text textSaveBox;
    [SerializeField] Image fondoTextSaveBox;
    [SerializeField] GameObject saveBoxPanel;
    //Color Change SaveBox
    bool changeColor;
    float timaCambiarColor;
    //Player
    [Header("Player")]
    [SerializeField] GameObject iconeZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite interactiveIcon;
    PlayerHere player;
    bool onSaveBox;

    // Update is called once per frame
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {

        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) PlayerInSaveBox();
        //Quiza hacer una animacion para los colores
        ColorPanel();

    }
    void PlayerInSaveBox()
    {
        if (player.playerImHere)
        {
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                onSaveBox = !onSaveBox;
            }
            if (onSaveBox)
            {
                saveBoxPanel.SetActive(true);
                iconeZone.SetActive(false);
            }
            else
            {
                saveBoxPanel.SetActive(false);
                iconeZone.SetActive(true);
                iconeZoneSprite.sprite = interactiveIcon;
            }
        }
        else
        {
            onSaveBox = false;
            iconeZone.SetActive(false);
            saveBoxPanel.SetActive(false);
        }
    }
    public void DeleteNum()
    {
        textSaveBox.text = textSaveBox.text.Remove(textSaveBox.text.Length - 1);
        numTeclasPress--;
    }
    public void CheckPassword()
    {
        if (textSaveBox.text == saveBoxPassword.ToString()) 
        {
            Debug.Log("Correcto");
            this.enabled = false;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            onSaveBox = false;
            iconeZone.SetActive(false);
            saveBoxPanel.SetActive(false);
            fondoTextSaveBox.color = Color.green;
        }
        else
        {
            //Reinicia
            Debug.Log("Incorrecto");
            textSaveBox.text = "";
            numTeclasPress = 0;
            fondoTextSaveBox.color = Color.red;
            changeColor = false;
        }
    }
    public void ColocarNum(int num)
    {
        if(textSaveBox.text.Length < 4)
        {
            textSaveBox.text += num.ToString();
            Debug.Log("Fal2");
            numTeclasPress++;
        }
        else if(textSaveBox.text.Length >= 4)
        {
            Debug.Log("Fal");
            //Si por casualidad tienen el mismo numero sustituira tambien el mismo numero
            textSaveBox.text = textSaveBox.text.Remove(textSaveBox.text.Length - 1);
            textSaveBox.text += num.ToString();
        }
        //CUando borres la tecla hay que saber cual es la ultima de la ultima. si borras la segunda, luego borra la primera
    }
    void ColorPanel()
    {
        if (!changeColor)
        {
            timaCambiarColor += Time.deltaTime;
            if (timaCambiarColor >= 0.5f)
            {
                fondoTextSaveBox.color = Color.white;
                changeColor = true;
            }
        }
        else
        {
            timaCambiarColor = 0;
        }
    }
}
