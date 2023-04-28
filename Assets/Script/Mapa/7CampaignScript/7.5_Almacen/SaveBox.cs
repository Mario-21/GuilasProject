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
    [Header("SaveBox Abierta")]
    [SerializeField] Sprite saveBoxAbierta;
    [SerializeField] GameObject reliquia;
    SpriteRenderer saveBoxSprite;
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
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
        saveBoxSprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) 
        {
            SaveBoxOpen();
        }
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
    }
    public void DeleteNum()
    {
        //Limita el numero de veces que puedes borrar un numero para que no de un index negativo
        if(textSaveBox.text.Length > 0)
        {
            textSaveBox.text = textSaveBox.text.Remove(textSaveBox.text.Length - 1);
            numTeclasPress--;
        }
    }
    public void CheckPassword()
    {
        if (textSaveBox.text == saveBoxPassword.ToString()) 
        {
            Debug.Log("Correcto");
            SaveBoxOpen();
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
    void SaveBoxOpen()
    {
        saveBoxSprite.sprite = saveBoxAbierta;
        reliquia.SetActive(true);
        this.enabled = false;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onSaveBox = false;
            iconeZone.SetActive(false);
            saveBoxPanel.SetActive(false);
        }
    }
}
