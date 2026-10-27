using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Read : MonoBehaviour
{
    public Text textoEnScena;
    [TextArea(2,10)]
    public string[] cadenaTexto;

    // Update is called once per frame
    private void Start()
    {
    }
    private void Update()
    {
        Keeping().ColocarTextoNota(textoEnScena);
    }
    public KeepText Keeping()
    {
        KeepText conservarTexto = new KeepText();
        return conservarTexto;
    }
}
