using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class TextAboutItemScene : MonoBehaviour
{
    public int indexMod;
    [Header("Texto UI")]
    public Text textoUi;
    public CanvasGroup textUiCanvas;
    [TextArea(2,5)]
    public string[] textoItem;
    [Header("Time Text")]
    public float timeLimitText;
    float timeText;
    [Header("Sound Effect Stuck")]
    [SerializeField] EventReference sound;

    PlayerHere player;
    bool seeText;

    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextOut();
        if (player.playerImHere)
        {
            if(Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sound);
                Change_See_Text();
                seeText = true;
                timeText = 0;
                
            }
        }

        if (seeText)
        {
            timeText += Time.deltaTime;
        }

        GoodbyeText();

    }
    void Change_See_Text()
    {
        //Coloca el texto 
        textoUi.text = textoItem[0];
        //Muestra el texto
        textUiCanvas.alpha = 1;
    }
    void GoodbyeText()
    {
        //Llegado al tiempo limite
        if (timeText >= timeLimitText)
        {
            //El texto ira desapareciendo poco a poco 
            textUiCanvas.alpha -= 0.01f;
            seeText = false;
        }
    }
    void TextOut()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            textUiCanvas.alpha = 0;
        }
    }

}
