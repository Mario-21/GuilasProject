using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BloquearMovimientoPlayer : MonoBehaviour
{
    [Header("Elementos Player")]
    public JugadorMovimiento player;
    public VidaPlayer vidaPlayer;
    public ArmaController pistol;
    public B8Arma b8;
    public ChangeWeapon conditionToChangeWeapon;
    public Stairs_Hidden stairs_Hidden;
    public Vision visionMode;
    [HideInInspector] public Rigidbody2D playerRB;

    [Header("Elemento Menu")]
    Inventory inventory;
    PauseControler pausaMenu;
    CreateObject itemCreate;

    float vidaActual;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        pausaMenu = FindObjectOfType<PauseControler>();
        itemCreate = FindObjectOfType<CreateObject>();
        stairs_Hidden = FindObjectOfType<Stairs_Hidden>();
        visionMode = FindObjectOfType<Vision>();
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    public void BloquearMovPlayer()
    {
        //Vision en falso primero y luego desactivar, seguramente no le de tiempo a ejecutarlo, por lo que tocara desactivarlo manualmente :-(
        visionMode.visiOn = false;
        visionMode.enabled = false;
        visionMode.visionShadder.SetActive(false);
        //Don't loss your life when you are blocked
        //vidaActual = vidaPlayer.vidaActual;
        //Deactive LifePlayer; Note: Keep the live when bloq is active
        vidaPlayer.enabled = false;
        player.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //Deactive Player
        player.enabled = false;
        playerRB.velocity = new Vector2(0f, 0f);
        player.animBodyP.SetBool("Player_Caminar", false);
        //Deactivate Pistol
        pistol.activarDisparo = false;
        pistol.enabled = false;
        pistol.mira.gameObject.SetActive(false);
        //Deactivate B8
        b8.activarB8 = false;
        b8.enabled = false;
        b8.mira.gameObject.SetActive(false);
        //Deactivate ChangeWeapon
        conditionToChangeWeapon.enabled = false;
        conditionToChangeWeapon.torso.layer = 1;
        //Desactivar escaleras
        stairs_Hidden.enabled = false;
        stairs_Hidden.laddersSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    //Electricidad (7.7) Paralizar
    public void BloquearMovConDaño()
    {
        //La vida se elimina. Este se hace para que la bajada de vida no vaya a destiempo con el golpe que recibes
        //Deactive Player
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.animBodyP.SetBool("Player_Caminar", false);
        //Deactivate Pistol
        pistol.activarDisparo = false;
        pistol.enabled = false;
        pistol.mira.gameObject.SetActive(false);
        //Deactivate B8
        b8.activarB8 = false;
        b8.enabled = false;
        b8.mira.gameObject.SetActive(false);
        //Deactivate ChangeWeapon
        conditionToChangeWeapon.enabled = false;
    }
    public void HabilitarMovPlayer()
    {
        //vidaPlayer.vidaActual = vidaActual;
        visionMode.enabled = true;
        stairs_Hidden.enabled = true;
        vidaPlayer.enabled = true;
        player.enabled = true;
        pistol.enabled = true;
        pistol.mira.gameObject.SetActive(true);
        b8.mira.gameObject.SetActive(true);
        if (SpecialWeapons.specialW.b8)
        {
            b8.enabled = true;
        }
        conditionToChangeWeapon.enabled = true;
    }
    public void HabilitarPlayerBarco()
    {
        //Habilitar las miras y las armas
        conditionToChangeWeapon.enabled = true;
        //Activa la mira y el arma
        pistol.enabled = true;
        pistol.mira.gameObject.SetActive(true);
        //Activa el B8
        b8.enabled = true;
        //Activa ChangeWeapon
        conditionToChangeWeapon.enabled = true;
        //Reactiva la vida
        vidaPlayer.enabled = true;

    }
    public void DeathPlayer()
    {
        //Bloquear Movimiento
        player.enabled = false;
        //Desactiva la subida y bajada de escaleras
        stairs_Hidden.enabled = false;
        stairs_Hidden.escalar = false;
        //Desactivar la  ocultacion
        stairs_Hidden.canHidden = false;
        //player.GetComponent<Animator>().SetBool("Walk", false);
        //Deactivate Pistol
        pistol.activarDisparo = false;
        pistol.enabled = false;
        pistol.mira.gameObject.SetActive(false);
        //Deactivate B8
        b8.activarB8 = false;
        b8.enabled = false;
        b8.mira.gameObject.SetActive(false);
        //Deactivate ChangeWeapon
        conditionToChangeWeapon.enabled = false;
        //Desactiva Inventario
        inventory.enabled = false;
        Inventory.gameIsPause = false;
        //Desactivar Menu Pausa
        pausaMenu.enabled = false;
        //Pausar
        
    }
    public void PausarGame()
    {
        player.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        //Detener Audio pasos
        AudioManager.instancia.PauseAudios();
        //Desactivar Armas
        pistol.enabled = false;
        conditionToChangeWeapon.enabled = false;
        b8.enabled = false;
        //Desactivar Inventario
        inventory.enabled = false;
        inventory.CloseInventory();
        //Destruir el item creado
        Destroy(itemCreate.objetoClone);
        //Desactivar Audio
        
    }
    public void ReanudarGame()
    {
        //Activar Armas Solo si no estoy escondido
        //Además de especificar si estoy en una cinematica o no, para que dentro de la cinematica no se habilite el poder disparar  
        if (!stairs_Hidden.imHidden)
        {
            pistol.enabled = true;
            conditionToChangeWeapon.enabled = true;
            b8.enabled = true;
        }

        //Activar Inventario
        inventory.enabled = true;

        AudioManager.instancia.ReanudaMusicAmbience();
    }
}
