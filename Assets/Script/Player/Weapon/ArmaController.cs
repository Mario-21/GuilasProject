using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaController : MonoBehaviour, IDataPersistence
{
    [Header("Info Weapon")]
    public Transform raySpawn;
    public GameObject bala;
    public Transform mira;
    public Transform brazo;
    public bool activarDisparo;
    [Tooltip("Al comenzar el nivel se coloca en true para cargar las balas del anterior")]
    public int indexModCargarAmmoData;
    [Header("Raycast Pistol")]
    public static bool preCollisionObject;
    public LayerMask maskCollision;
    [Header("Aim")]
    public float timeAppearAim;
    public float timeAppearAimLimit;
    [Header("Municion Text")]
    public int municion;
    public int municionTotal;
    public Text municionText;
    [Header("Disparos")]
    public EffectDisparo shootAnim;
    float cooldown;
    public float refreshWeapon = 0.5f;

    [Header("Weapon Sprite")]
    public SpriteRenderer pistola;
    public SpriteRenderer pistolaCintura;
    public GameObject bullet;
    //Cambiar Layer
    [Header("Infiltración Data")]
    [SerializeField] OcultacionByWeapon theySeeYou;



    Camera pruebaCamera;
    public void LoadData (GameData data)
    {
        //Colocar un bool para que me deje cargar la munición una sola vez al inicio de cada nivel
        //Este bool solo se colocara en true al inicio de cada nivel para que establezca la munición solo al inicio
        //Tras establecerla pasara a usar el método que existia antes de una ListaPlayer haciendo de puente
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexModCargarAmmoData].modificacion) 
        {
            Debug.Log("Eye Liener");
            this.municion = data.ammoActual;
            //Establece la munición con la que empiezas el nivel y la que va a ir utilizando para viajar entre escenas.
            ListDataPlayer.listDataPlayer.ammoPlayerNow = data.ammoActual;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModCargarAmmoData].modificacion = true;
        }
    }
    public void SaveData(ref GameData data)
    {
        //Esto solo ocurre al final
        data.ammoActual = this.municion;
    }
    private void Awake()
    {
        pistola = GetComponent<SpriteRenderer>();
        pruebaCamera = GameObject.FindGameObjectWithTag("CameraDisparo").GetComponent<Camera>();
    }
    void Start()
    {
        //Establecer la municion Total con la inicial;
        municionTotal = municion;
        //Si cierro Unity y el lunes esto no funciona, habrá que cambiarlo para que solo ejecute una vez 
        AmmoBetweenSameLevel();
        //soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        municionText.text = municion.ToString();

        DiferenciaAmmo();
        DrawWeapon();
        UseWeapon();
    }
    private void LateUpdate()
    {
        if (activarDisparo)
        {
            brazo.up = brazo.position - mira.position;
        }
        //mira.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //brazo.up = brazo.position - mira.position;
    }

    void AmmoBetweenSameLevel() 
    {
        //Cuando ya hayas comenzado el nivel, no  te cargará más munición por parte del GameData, a no ser que reinicies o salgas del juego.
        //La carga única se hace para que el jugador no pueda farmear munición infinita saliendo y entrando del juego.
        //Para poder seguir conectando la munición entre niveles sin que se guarde la munición en el GameData, existe la ammoData
        //AmmoData esta solo para que almacene dicha munición en una lista de datos del jugador que tiene información del nivel que juegas en ese momento
        //así la munición viaja entre las escenas de dicho nivel sin necesidad de guardarla
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModCargarAmmoData].modificacion)
        {
            municion = ListDataPlayer.listDataPlayer.ammoPlayerNow;
        }
    }
    void DiferenciaAmmo()
    {
        if(municion != municionTotal)
        {
            ListDataPlayer.listDataPlayer.ammoPlayerNow = municion;
            municionTotal = municion;
        }
    }
    void DrawWeapon()
    {
        //Draw the weapon or keep it
        if (Input.GetButtonDown("Draw_Weapon"))
        {
            activarDisparo = !activarDisparo;

            if (!activarDisparo)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.outWeapon);
            }
            else
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.drawWeapon);
            }
        }
    }
    void UseWeapon()
    {

        CoolDownWeapon();
        //Draw You Weapon
        if (activarDisparo)
        {
            {
                //Saca el arma
                pistolaCintura.enabled = false;
                pistola.enabled = true;
                //They can see you
                theySeeYou.VisibleOn();
                //You aim with the gun
                mira.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                municionText.enabled = true;
                mira.position = pruebaCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -pruebaCamera.transform.position.z));
                
                if (municion > 0)
                {
                    municionText.color = Color.white;
                    //Añadir cooldown;
                    if (cooldown <= 0)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            //Sound
                            //soundManager.SeleccionAudio(soundManager.audiosArmas, 0, 1f, 0);
                            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.shoot);
                            //Effect
                            shootAnim.AnimationEffectDisparo();
                            //Attack
                            Ataque();
                            cooldown = refreshWeapon;
                            municion -= 1;
                            theySeeYou.visible = true;
                        }
                    }
                }
                else if (municion <= 0)
                {
                    //Show your ammo in red 
                    municionText.color = Color.red;
                    if (Input.GetButtonDown("Fire1"))
                    {
                        //soundManager.SeleccionAudio(soundManager.audiosArmas, 1, 1f, 0);
                        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.noAmmo);
                        Debug.Log("Estas sin munición");
                    }

                }
            }
        }
        //Keep your Weapon
        else
        {
            //Guarda el arma
            pistola.enabled = false;
            pistolaCintura.enabled = true;
            municionText.enabled = false;
            mira.localPosition = new Vector2(0f, mira.localPosition.y);
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            brazo.transform.rotation = Quaternion.identity;
            //Si has disparado antes de ocultarte y aun te queda tiempo no vas a poder volver a ser invisible hasta que se acabe el tiempo
            if(!theySeeYou.visible) theySeeYou.VisibleOff();
            if (!ListaAttackSoldado.modeSoldiers.activeAllAttackSoldiers) theySeeYou.isVisible.enabled = false;
        }
    }
    void CoolDownWeapon()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (cooldown < 0)
        {
            cooldown = 0;
        }
    }
    void Ataque()
    {
        GameObject balaClon = Instantiate(bullet, raySpawn.position, raySpawn.rotation);
        //Drawray() detect the collision To the object you aim and prevent that Detectar_Echar breaks
        DrawRay();
    }
    void DrawRay()
    {
        RaycastHit2D rayPistol;
        rayPistol = Physics2D.Raycast(raySpawn.position, DistanceMiraPistol().normalized, 10 ,maskCollision);
        if (rayPistol)
        {
            preCollisionObject = true;
        }
    }
    Vector2 DistanceMiraPistol()
    {
        Vector2 distanceMiraPistol;
        return distanceMiraPistol = mira.position - raySpawn.position;
    }
}

