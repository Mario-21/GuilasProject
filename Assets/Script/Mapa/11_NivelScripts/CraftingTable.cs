using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;

public class CraftingTable : MonoBehaviour
{
    PlayerHere player;
    public int indexModCrafteo;
    [Header("Items Requeridos Crafteo")]
    //Ambos tendrán el mismo tamaño
    [SerializeField] List<bool> itemsCraft;
    [SerializeField] List<int> indexItemCraft;
    [Header("Numero Items Necesarios")]
    //Items necesarios para el crafteo 
    public int limitCountItemCrafteo;
    public int countItemCrafteo;
    [Header("Tiempo para Craftear")]
    public float timeCraftLimit;
    public float timeCraft;

    [Header("UI Crafteo")]
    [SerializeField] Image iconCrafteoUI;
    [Header("IconoCrafteo")]
    [SerializeField] GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite iconCrafting;
    [Header("Items En Mesa")]
    public GameObject itemCrafteado;
    public List<GameObject> itemsEnMesa;
    [Header("Particulas Crafting")]
    public GameObject estelaHumo;

    EventInstance craftingSound;
    int soundEffect;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        craftingSound = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.crafteo);
        //Si has crafteado el item, ya no puedes volverlo a craftearlo
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModCrafteo].modificacion)
        {
            itemCrafteado.SetActive(true);
            this.enabled = false;
        }
        //Asigna a la lista de bools, itemsCraft, sus respectivas variables del crafteo
        //NOTA: La única condicion para que no se rompa es colocar las cosas ordenadas
        for (int i = 0; i < itemsCraft.Count; i++)
        {
            itemsCraft[i] = StatusGameobjectsVariables.statusGameobject.modificacion[indexItemCraft[i]].modificacion;
            if (itemsCraft[i])
            {
                countItemCrafteo++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            //Puedo Craftear
            CanCraft();
        }
    }
    void CanCraft()
    {
        //Puedes craftear si has llegado al numero de items requerido y si no has crafteado previamente.
        if(countItemCrafteo >= limitCountItemCrafteo && !StatusGameobjectsVariables.statusGameobject.modificacion[indexModCrafteo].modificacion)
        {
            //Mostrar icono
            iconoZone.SetActive(true);
            iconeZoneSprite.sprite = iconCrafting;

            Debug.Log("Puedo craftear");
            Craftear();
        }
    }
    void Craftear()
    {
        if (Input.GetButton("Action"))
        {
            //La barra de la UI comenzara a llenarse
            timeCraft += 0.01f;
            iconCrafteoUI.fillAmount = timeCraft;
            //Sonido Crafting
            if(soundEffect < 1)
            {
                craftingSound.start();
                soundEffect++;
            }
            //Al terminar el crafteo
            if (timeCraft >= timeCraftLimit)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.endCrafteo);
                //Aparece una estela de humo para que no se vea como crea el objeto
                Instantiate(estelaHumo, transform.position, Quaternion.identity);
                //Desapaarecen los items en mesa
                for (int e = 0; e < itemsEnMesa.Count; e++)
                {
                    itemsEnMesa[e].SetActive(false);
                }
                //Terminaste de crafteo UI
                timeCraft = 0;
                iconCrafteoUI.fillAmount = 0;
                //Indicar que has acabado el crafteo
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModCrafteo].modificacion = true;
                //Desactivar este Script.
                this.enabled = false;
                //Icono fuera ya que has acabado de craftear
                iconoZone.SetActive(false);
                //Aparece el objeto crafteado
                itemCrafteado.SetActive(true);
                //Se detiene el sonido
                craftingSound.stop(STOP_MODE.ALLOWFADEOUT);
                soundEffect = 0;
                Debug.Log("Crafteo completado");
            }
        }
        else
        {
            soundEffect = 0;
            craftingSound.stop(STOP_MODE.ALLOWFADEOUT);
            timeCraft = 0;
            iconCrafteoUI.fillAmount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconoZone.SetActive(false);
        }
    }
}
