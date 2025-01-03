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
    [Header("Death Data")]
    public bool youWantDied;
    public int deathScene;
    int once;
    BloquearMovimientoPlayer bloquear;
    [Header("Recovery ammo")]
    public B8Arma b8Weapon;

    Animator animPlayer;
    private void Awake()
    {
        animPlayer = GetComponent<Animator>();
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
    }
    public void Daño(float daño)
    {
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
                animPlayer.SetBool("Dead", true);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy")) 
        {
            Daño(34f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Dardo")) 
        { 
            Daño(15f);
        }
    }

    //I need that player recovery ammo, because if you made with b8 you can't fix the problem with the collision in player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("B8"))
        {
            if (SpecialWeapons.specialW.b8)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.b8Recoger);
                b8Weapon.municionTotal++;
                Destroy(collision.gameObject);
            }
        }
    }
}
