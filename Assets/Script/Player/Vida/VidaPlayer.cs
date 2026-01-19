using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VidaPlayer : MonoBehaviour
{
    [Header("Life Data")]
    public float vidaActual;
    [SerializeField] float vidaDiferencia;
    public float vidaTotal;
    Image vidaUI;
    [Header("Estado Invencibilidad")]
    public bool invencible;
    public float invencLimitTime;
    public float invencTime;
    [Header("Death Data")]
    public bool youWantDied;
    public int deathScene;
    int once;
    BloquearMovimientoPlayer bloquear;
    [Header("Recovery ammo")]
    public B8Arma b8Weapon;
    public ChangeWeapon changeWeapon;
    Stairs_Hidden definirEstadoPlayer;

    [Header("Animacion Jugador")]
    public Animator animPlayerBody;
    public Animator animPlayerHead;

    public enum TipoAnimacion
    {
        Antiguo,
        Nuevo
    }
    public TipoAnimacion tipoAnimacion;
    private void Awake()
    {
        definirEstadoPlayer = GetComponent<Stairs_Hidden>();
        animPlayerBody = GetComponent<Animator>();
        vidaUI = GameObject.Find("LifeBar").GetComponent<Image>();
    }
    void Start()
    {
        //SceneManager.LoadSceneAsync(scenaTutorial, LoadSceneMode.Additive);
        bloquear = FindObjectOfType<BloquearMovimientoPlayer>();
        vidaActual = ListDataPlayer.listDataPlayer.vidaPlayerNow;
        vidaDiferencia = vidaActual;
    }

    // Update is called once per frame
    void Update()
    {
        vidaUI.fillAmount = vidaActual / vidaTotal;
        Muerte();
        SaveVidaData();
        TiempoInvencibilidad();
    }
    public void Daño(float daño)
    {
        switch (tipoAnimacion)
        {
            case TipoAnimacion.Antiguo:
                animPlayerBody.SetTrigger("Hurt");
                break;
            case TipoAnimacion.Nuevo:
                animPlayerBody.SetTrigger("Player_Herida");
                animPlayerHead.SetTrigger("P_Herir");
                break;
        }
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.damage);
        vidaActual -= daño;
        SaveVidaData();
    }
    void Muerte()
    {
        if (vidaActual <= 0) 
        {
            if (youWantDied)
            {
                //Limpia los audios
                AudioManager.instancia.CleanUp();
                Debug.Log("Te moriste");
                bloquear.DeathPlayer();
                switch (tipoAnimacion)
                {
                    case TipoAnimacion.Antiguo:
                        animPlayerBody.SetBool("Dead", true);
                        break;
                    case TipoAnimacion.Nuevo:
                        animPlayerBody.SetBool("Player_Muerte", true);
                        animPlayerHead.SetTrigger("P_Muerte");
                        break;
                }
            }
        }

    }
    public void CallDeathMenu()
    {
        if (youWantDied && once < 1)
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync(deathScene, LoadSceneMode.Additive);
            once++;
        }
    }
    void SaveVidaData()
    {
        //Cuando mi vida varíe guardara mi vida actual en el objeto no destruible 
        if(vidaActual != vidaDiferencia)
        {
            //En caso de que no funcione, hacer que se espere unos segundos a guardarlo.
            ListDataPlayer.listDataPlayer.vidaPlayerNow = vidaActual;
            vidaDiferencia = vidaActual;
        }
    }
    void TiempoInvencibilidad()
    {
        if (invencible)
        {
            invencTime += Time.deltaTime;
            if(invencTime >= invencLimitTime)
            {
                invencible = false;
                invencTime = 0;
            }
        }
    }
    void EstadoBCatArma()
    {
        //Si esto no funciona colocar un bool que active una variable en el b8 que haga todo esto y cuando termine la vuelve a colocar en falso y solo se active al colisionar con el b8
        //Hay que detectar el changeweapon ya que cuando lanzes la BCat SIEMPRE va a quedar en falso el activarb8

        //ChangeWeapon.changeweapon = B8
        //!ChangeWeapon.changeweapon = Pistola

        if (!changeWeapon.changeWeapon)
        {
            b8Weapon.bCatCintura.enabled = true;
        }
        else
        {
            b8Weapon.gameObject.SetActive(true);
            b8Weapon.b8Sprite.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si yo no estoy escondido, significa que puedo recibir daño
        if (!definirEstadoPlayer.imHidden)
        {
            if (collision.gameObject.CompareTag("BulletEnemy"))
            {
                if (!invencible)
                {
                    Debug.Log("HitMarket");
                    Daño(34f);
                    invencible = true;
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("Dardo"))
            {
                Daño(15f);
            }
        }
        
    }

    //I need that player recovery ammo, because if you made with b8 you can't fix the problem with the collision in player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("B8"))
        {
            if (SpecialWeapons.specialW.b8)
            {
                EstadoBCatArma();
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.b8Recoger);
                b8Weapon.municionTotal++;
                Destroy(collision.gameObject);
            }
        }
    }
}
