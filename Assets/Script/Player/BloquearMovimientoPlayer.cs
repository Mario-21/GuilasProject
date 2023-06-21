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
    Stairs_Hidden stairs_Hidden;

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
        
    }

    public void BloquearMovPlayer()
    {
        //Don't loss your life when you are blocked
        //vidaActual = vidaPlayer.vidaActual;
        //Deactive LifePlayer; Note: Keep the live when bloq is active
        vidaPlayer.enabled = false;
        //Deactive Player
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.GetComponent<Animator>().SetBool("Walk", false);
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
    //Electricidad (7.7) Paralizar
    public void BloquearMovConDaño()
    {
        //La vida se elimina. Este se hace para que la bajada de vida no vaya a destiempo con el golpe que recibes
        //Deactive Player
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.GetComponent<Animator>().SetBool("Walk", false);
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
        player.enabled = false;
        //Llamar Death Anim
        player.GetComponent<Animator>().SetBool("Walk", false);
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
        //Desactivar Armas
        pistol.enabled = false;
        conditionToChangeWeapon.enabled = false;
        b8.enabled = false;
        //Desactivar Inventario
        inventory.enabled = false;
        inventory.CloseInventory();
        //Destruir el item creado
        Destroy(itemCreate.objetoClone);
    }
    public void ReanudarGame()
    {
        //Activar Armas Solo si no estoy escondido
        if (!stairs_Hidden.imHidden)
        {
            pistol.enabled = true;
            conditionToChangeWeapon.enabled = true;
            b8.enabled = true;
        }

        //Activar Inventario
        inventory.enabled = true;
    }
}
