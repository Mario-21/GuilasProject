using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStatusVariableAction : MonoBehaviour
{
    [Header ("Condiciones")]
    public string nameTagTrigger;
    [Header("Condicion Cumplida")]
    public int indexMod;
    [SerializeField] bool success;
    [Header("Condicion Fallida")]
    [Tooltip("Al añadir el indexModFallido, se transforma en un evento de única oportunidad. SOLO se puede ejecutar una vez, o sale A o sale B")]
    public int indexModFallida;
    [SerializeField] bool fail;
    [Header("Lista soldados y tipo de condicion")]
    public List<SoldierLife> vidaSoldados;

    public enum TipoCondicionSoldados
    {
        Todos_muertos,
        Todos_vivos,
        Uno_vivo
        //Uno_muerto puede quitarse dado que es incluyente de Todos_vivos, es lo mismo dicho de diferente manera
    }
    public TipoCondicionSoldados tipoCondicionSoldados;

    int totalSoldados;
    [Header("Método de activación con Player")]
    public AccionPlayerActive accionPlayer;
    public enum AccionPlayerActive
    {
        Area_Trigger,
        Press_Button
    }
    public bool playerEnArea;

    void Start()
    {
        totalSoldados = vidaSoldados.Count;
        success = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
        fail = StatusGameobjectsVariables.statusGameobject.modificacion[indexModFallida].modificacion;
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion || StatusGameobjectsVariables.statusGameobject.modificacion[indexModFallida].modificacion)
        {
            //Si variable esta activa, quiere decir que las condiciones ya se cumplieron una vez, ya lo que pase después te da igual
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (accionPlayer)
        {
            case AccionPlayerActive.Press_Button:
                if (playerEnArea)
                {
                    if (Input.GetButtonDown("Action"))
                    {
                        ActiveIndexStatusSoldiers();
                    }
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameTagTrigger))
        {
            switch (accionPlayer)
            {
                case AccionPlayerActive.Area_Trigger:
                    ActiveIndexStatusSoldiers();
                    break;
                case AccionPlayerActive.Press_Button:
                    playerEnArea = true;
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameTagTrigger))
        {
            switch (accionPlayer)
            {
                case AccionPlayerActive.Press_Button:
                    playerEnArea = false;
                    break;
            }
        }
    }
    void ActiveIndexStatusSoldiers()
    {
        switch (tipoCondicionSoldados)
        {
            case TipoCondicionSoldados.Todos_muertos:
                for (int w = 0; w < vidaSoldados.Count; w++)
                {
                    if(vidaSoldados[w].vida > 0)
                    {
                        Debug.Log("El soldado " + vidaSoldados[w].name + " ha fallecido, se ha cumplido una parte de la condicion");
                        vidaSoldados.Remove(vidaSoldados[w]);
                        //Como ya no se puede cumplir la condición desactiva el script
                        StatusGameobjectsVariables.statusGameobject.modificacion[indexModFallida].modificacion = true;
                        this.enabled = false;
                        //return;
                    }
                }
                if (vidaSoldados.Count == totalSoldados)
                {
                    Debug.Log("Han muerto TODOS, por tanto, la condicion se cumple");
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    //Como ya se ha cumplido la condicion ya no necesitas que se ejecute más
                    this.enabled = false;
                }
                break;
            case TipoCondicionSoldados.Todos_vivos:
                for (int w = 0; w < vidaSoldados.Count; w++)
                {
                    //Revisa si alguien ha muerto, en cuanto detecte que alguien ha fallecido rompe la ejecución porque ya sabes que no se va a cumplir
                    if (vidaSoldados[w].vida <= 0)
                    {
                        Debug.Log("El soldado " + vidaSoldados[w].name + " ha fallecido, se NO CUMPLE la condicion, fuera");
                        vidaSoldados.Remove(vidaSoldados[w]);
                        //Como ya no se puede cumplir la condición desactiva el script
                        StatusGameobjectsVariables.statusGameobject.modificacion[indexModFallida].modificacion = true;
                        this.enabled = false;
                        //return;

                    }
                }
                if (vidaSoldados.Count == totalSoldados)
                {
                    Debug.Log("Han sobrevivido TODOS, por tanto, la condicion se cumple");
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    //Como ya se ha cumplido la condicion ya no necesitas que se ejecute más
                    this.enabled = false;
                }
                break;
                //Mientras haya mínimo 1 vivo
            case TipoCondicionSoldados.Uno_vivo:
                for (int w = 0; w < vidaSoldados.Count; w++)
                {
                    //Revisa si alguien ha muerto, en cuanto detecte que alguien ha fallecido rompe la ejecución porque ya sabes que no se va a cumplir
                    if (vidaSoldados[w].vida <= 0)
                    {
                        totalSoldados--;
                        Debug.Log("El soldado " + vidaSoldados[w].name + " ha fallecido, se resta 1");
                        vidaSoldados.Remove(vidaSoldados[w]);
                    }
                }
                if (totalSoldados > 0)
                {
                    Debug.Log("Ha sobrevivido al menos 1, por tanto, la condicion se cumple");
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    //Como ya se ha cumplido la condicion ya no necesitas que se ejecute más
                    this.enabled = false;
                }
                else if (totalSoldados <= 0)
                {
                    Debug.Log("Lo siento, pero ya no se puede cumplir la condicion, no ha sobrevivido nadie");
                    //Como ya no se puede cumplir la condición desactiva el script
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexModFallida].modificacion = true;
                    this.enabled = false;
                }
                break;
        }
    }
}
