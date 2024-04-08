using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Polipasto_Normal : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    [Header("Subir o Bajar")]
    public bool mov;
    public int indexPiso;

    [Header("Destino")]
    public Transform[] destinos;

    [Header("Velocidad")]
    public float velocidad;

    [Header("Cuerda Polipasto")]
    [SerializeField] bool have_Cuerda;
    [SerializeField] SpriteRenderer cuerda;
    float cuerda_Size;

    [Header("Cooldown ascensor")]
    public float timeCooldownLimit;
    float timeCooldown;

    [HideInInspector] public StudioEventEmitter emitterAscensor;
    int reproduceAscensor;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        cuerda_Size = velocidad / 10;
    }
    private void Start()
    {
        emitterAscensor = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.ascensorMove, this.gameObject);
    }
    void FixedUpdate()
    {
        UpDownElevator();
    }
    void UpDownElevator()
    {

        Vector3 movePosition = transform.position;
        movePosition.y = Mathf.MoveTowards(transform.position.y, destinos[indexPiso].position.y, velocidad * Time.fixedDeltaTime);
        rb.MovePosition(movePosition);
        //Me muevo
        if (destinos[indexPiso].position != transform.position)
        {
            //Cuerda se expande o retrae
            if(have_Cuerda) CuerdaAscensor();
            //Reproducir sonido
            
            if(reproduceAscensor < 1)
            {
                emitterAscensor.Play();
                reproduceAscensor++;
            }
            
            mov = true;

        }
        else
        {
            //Ya no te mueves
            mov = false;
            //Deja de reproducir el audio
            emitterAscensor.Stop();
            reproduceAscensor = 0;
            //Esperas un tiempo para poder reanudar la marcha
            if (timeCooldown < timeCooldownLimit)
            {
                timeCooldown += Time.deltaTime;
            }
            //Una vez pasada la espera te vuelves a dirigir a tu siguiente posicion
            else
            {
                timeCooldown = 0;
                if(indexPiso < destinos.Length - 1)
                {
                    indexPiso++;
                }
                else if (indexPiso >= destinos.Length - 1)
                {
                    indexPiso = 0;
                }
            }
        }
    }
    void CuerdaAscensor()
    {
        if(DistanciaElevatorDestino().y < 0)
        {
            cuerda.size += new Vector2(0f, cuerda_Size);
        }
        else
        {
            cuerda.size -= new Vector2(0f, cuerda_Size);
        }
    }
    Vector2 DistanciaElevatorDestino()
    {
        Vector2 distaciaElevatorDestino;
        return distaciaElevatorDestino = destinos[indexPiso].position - transform.position;
    }
}
