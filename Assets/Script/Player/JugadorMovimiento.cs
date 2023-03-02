
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JugadorMovimiento : MonoBehaviour
{
    Rigidbody2D rb;
    Transform myTransform;
    public static bool direccionBala;


    [Header("LayerMask")]
    [SerializeField] LayerMask groundMask;

    [Header("Base Player Data")]
    public float velocidadBase;
    [SerializeField] private float aceleracionBase;
    [SerializeField] private float speedBase;

    [Header("Datos Movimiento")]
    public float velocidad;
    [SerializeField] private float aceleracion;
    [SerializeField] private float speed;
    [SerializeField] private float groundLinearDrag;
    public float horizontalMov;

    bool cambiarDireccion => (rb.velocity.x > 0 && horizontalMov < 0) || (rb.velocity.x < 0 && horizontalMov > 0);

    [Header("Jump Data")]
    [SerializeField] float jumpForce = 12f;
    [SerializeField] float airLinearDrag = 2.5f;
    [SerializeField] float fallMultiplier = 8f;
    [SerializeField] float lowJumpFallMultiplier = 5f;
    [SerializeField] int extraJump;
    Queue<KeyCode> almacenBotonJump;
    bool canJump => Input.GetButtonDown("Jump") && onGround || Input.GetButtonDown("Jump") && tiempoEnAire <= 0.25f && !onGround;

    [Header("Ground Collision Data")]
    [SerializeField] float groundRaycastLegth;
    public bool onGround;
    [SerializeField] float tiempoEnAire;

    [Header("Water Collision Data")]
    public float velocidadWater;
    public float aceleracionWater;
    public float speedWater;
    public bool onWater;

    [Header("Escaleras")]
    public Stairs_Hidden subirEscalera;

    [Header("Animacion")]
    public Animator anim;

    [Header("Hidden")]
    public GameObject torso;

    [Header("Disparo Texto")]
    public Canvas municionTexto;

    [Header("Weapons and Conditions")]
    [SerializeField] ChangeWeapon conditionWeapon;
    [SerializeField] B8Arma b8;
    [SerializeField] ArmaController pistol;


    SoundManager soundManager;
    VidaPlayer vidaPlayer;
    CheckPointController spawn;

    //cambiar la posicion del transform de Altura a mi Transform
    //calcular El daño >10 25 daño >20 50 etc.
    //dibujar rayos
    //comprobar en valor absoluto la diferencia de altura
    private void Awake()
    {
        almacenBotonJump = new Queue<KeyCode>();
        spawn = FindObjectOfType<CheckPointController>();
        soundManager = FindObjectOfType<SoundManager>();
        //Cuando interactues con el portatil seras visible
    }
    void Start()
    {

        anim = GetComponent<Animator>();
        vidaPlayer = GetComponent<VidaPlayer>();
        direccionBala = true;
        rb = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();

        //transform.position = spawn.checkpoints[0].position;

    }

    void Update()
    {
        horizontalMov = GetInput().x;

        if (canJump && extraJump < 1) Jump();

        //Almacena la cantidad de saltos, para que no sobrepases el numero limite de saltos.
        if (almacenBotonJump.Count < 1) if (Input.GetButtonDown("Jump")) { almacenBotonJump.Enqueue(KeyCode.Space); Invoke("QuitarJump", 0.1f); };

        CambiarDireccionDisparo();

    }
    private void FixedUpdate()
    {
        CheckCollisionGround();
        CheckCollisionWater();
        MoveCharacter();
        if (onGround)
        {
            ApplyLinearGroundDrag();
        }
        else if (!onGround && !onWater)
        {
            ApplyLinearAirDrag();
            FallMultiplier();
        }


    }

    

    Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontalMov, 0f) * aceleracion);
        if (Mathf.Abs(rb.velocity.x) > speed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * velocidad, rb.velocity.y);
        }

        //Animación 
        anim.SetBool("Walk", true);
        //Caminar
        //if (Mathf.Abs(horizontalMov) > 0) anim.SetBool("Walk", true);
        //Parar
        if (horizontalMov == 0) anim.SetBool("Walk", false);

        //Escala del Personaje, cuando no apuntas con el arma
        //if you 
        if (!conditionWeapon.changeWeapon)
        {
            if (!pistol.activarDisparo)
            {
                if (horizontalMov == 1) transform.localScale = new Vector3(1, 1, 1);
                if (horizontalMov == -1) transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (!b8.activarB8)
            {
                Debug.Log("Wepon 8V");
                if (horizontalMov == 1) transform.localScale = new Vector3(1, 1, 1);
                if (horizontalMov == -1) transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }
    void ApplyLinearGroundDrag()
    {
        if(Mathf.Abs(horizontalMov) < 0.4 || cambiarDireccion)
        {
            rb.drag = groundLinearDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    void ApplyLinearAirDrag()
    {
        rb.drag = airLinearDrag;
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    void CheckCollisionGround()
    {
        //Rocortar Rayo al saltar
        onGround = Physics2D.Raycast(transform.position * groundRaycastLegth, Vector2.down, groundRaycastLegth, groundMask);
        if (onGround)
        {
            tiempoEnAire = 0;
            if(almacenBotonJump.Count < 1) extraJump = 0;
            
        }
        else
        {
            tiempoEnAire += Time.deltaTime;
            if(tiempoEnAire > 0.25f) extraJump++;
        }
    }
    void CheckCollisionWater()
    {
        if (onWater) 
        {
            velocidad = velocidadWater;
            speed = speedWater;
            aceleracion = aceleracionWater;
        }
        else
        {
            velocidad = velocidadBase;
            speed = speedBase;
            aceleracion = aceleracionBase;
        }
    }
    void FallMultiplier()
    {
        if(rb.velocity.y < 0) //Si estas cayendo
        {
            if (!subirEscalera.zonaEscalada) rb.gravityScale = fallMultiplier;
        }
        else if(rb.velocity.y > 0 && !Input.GetButtonDown("Jump")) //Si acabas de saltar
        {
            if (almacenBotonJump.Count >= 1) extraJump++;
            else if (almacenBotonJump.Count < 1 && tiempoEnAire > 0.25f) {extraJump++;}


            if (!subirEscalera.zonaEscalada) rb.gravityScale = lowJumpFallMultiplier;
        }
        else
        {
            if(!subirEscalera.zonaEscalada) rb.gravityScale = 1f;
        }
    }
    public void CambiarDireccionDisparo()
    {
        if(myTransform.localScale.x == 1)
        {
            direccionBala = true;
            //Escala Disparo
            municionTexto.transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        }
        if (myTransform.localScale.x == -1)
        {
            direccionBala = false;
            //Escala Disparo
            municionTexto.transform.localScale = new Vector3(-0.1f, 0.1f, 1f);
        }
    }
    void QuitarJump()
    {
        almacenBotonJump.Dequeue();
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = golpeRayEspalda ? Color.white : Color.red;
        //Gizmos.DrawRay(puntoEspalda.position, -puntoEspalda.right * espaldaRayDistance);

        Gizmos.color = onGround ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLegth);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            onWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            onWater = false;
        }
    }









}
