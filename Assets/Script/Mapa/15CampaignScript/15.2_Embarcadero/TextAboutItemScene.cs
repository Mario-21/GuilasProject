using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAboutItemScene : MonoBehaviour
{
    [Header("Texto UI")]
    public Text textoUi;
    public CanvasGroup textUiCanvas;
    [TextArea(2,5)]
    public string[] textoItem;
    [Header("Time Text")]
    public float timeLimitText;
    float timeText;


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
        Debug.Log("Tiempo transcurrido " + timeText);
        if (player.playerImHere)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
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

}
