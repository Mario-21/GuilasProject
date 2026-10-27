using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class OutLona : MonoBehaviour
{
    public int indexMod;

    [Header("Items Delete")]
    public List<GameObject> itemDelete;
    [Header("Items Appear")]
    public List<GameObject> itemAppear;
    [Header("SFX Lona")]
    [SerializeField] EventReference sfxLona;

    PlayerHere player;

    public enum ActionItemStatus
    {
        Aparecer,
        Desaparecer,
        Both
    }
    public ActionItemStatus whatAction;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
            ItemsAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sfxLona);
                ItemsAction();
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                this.enabled = false;
            }
        }
    }
    void ItemsAction()
    {
        Show_Delete_Items shows = new Show_Delete_Items();
        switch (whatAction)
        {
            case ActionItemStatus.Aparecer:
                shows.ShowItems(itemAppear);
                break;
            case ActionItemStatus.Desaparecer:
                shows.DeleteItems(itemDelete);
                break;
            case ActionItemStatus.Both:
                shows.ShowItems(itemAppear);
                shows.DeleteItems(itemDelete);
                break;
        }
    }


}
