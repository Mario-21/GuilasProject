using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificarTipoPaderes : MonoBehaviour
{
    public LayerMask pared;

    [Header("Vectores y Ángulo de la Rampa")]
    public Vector2 vectorOrigenPared;
    public Vector2 vectorSueloPared;

    public Vector2 vectorOrigenParedEspalda;
    public Vector2 vectorSueloParedEspalda;

    public float anguloRampaNormal;
    public float anguloRampaEspalda;
    public float anguloLímite;

    [Header("Tipo Pared")]
    public IdentificarPared identificarPared;
    public enum IdentificarPared
    {
        Pared,
        Rampa,
        Default
    }

    [Header("Punto Origen")]
    public Transform puntoOrigen;

    [Header("Direccion Vectores")]

    //Estos me son utiles dado que solo tengo que moverlos manualmente y no tengo que estar tocando propiedades, llenando de más datos el script.

    public Transform direccionHorizontalNormal;
    public Transform direccionHorizontalEspalda;
    public Transform direccionVertical;

    [Header("Registro Datos Pared")]
    public Vector2 vectorParedInicial;
    public Vector2 vectorSueloInicial;
    public Vector2 vectorParedRetroceso;
    public Vector2 vectorSueloRetroceso;

    public Vector2 vectorParedInicialEspalda;
    public Vector2 vectorSueloInicialEspalda;
    public Vector2 vectorParedRetrocesoEspalda;
    public Vector2 vectorSueloRetrocesoEspalda;

    [Header("Distancia Registro Paredes")]

    public float distanciaRegistroInicial;
    public float distanciaRegistroRetroceso;

    public float distanciaRegistroInicialEspalda;
    public float distanciaRegistroRetrocesoEspalda;

    [Header("Cuerpo Player")]
    public Transform playerPosition;
    public Rigidbody2D playerRgB;
    public JugadorMovimiento jugadorMovimiento;
    [SerializeField] bool resetPropiedades;

    [Header("Propiedades en Rampa")]
    public float aceleracionRampa;
    public float groundLinearDragRampa;

    [Header("Propiedades en Pared")]
    [SerializeField] float aceleracionBaseNormal;
    [SerializeField] float groundLinearDragBaseNormal;

    void Start()
    {
        aceleracionBaseNormal = jugadorMovimiento.aceleracionBase;
        groundLinearDragBaseNormal = jugadorMovimiento.groundLinearDrag;
        
    }
    private void Update()
    {
        DefinirAnguloParedFrente();
        DefinirAnguloParedEspalda();
        DefinirSinPared();
        CambioPropiedadesPlayer();
    }
    void DefinirAnguloParedFrente()
    {
        if (RayoPared(direccionHorizontalNormal))
        {
            Debug.DrawRay(puntoOrigen.position, DireccionPared(direccionHorizontalNormal),Color.green);
            if (RayoPared(direccionHorizontalNormal).collider)
            {
                vectorParedInicial = RayoPared(direccionHorizontalNormal).point;
                vectorParedRetroceso = VectorParedSuelo(distanciaRegistroRetroceso, vectorParedInicial);
                if (RayoParedSuelo(VectorParedSuelo(distanciaRegistroInicial, vectorParedInicial)).collider)
                {
                    vectorSueloInicial = RayoParedSuelo(VectorParedSuelo(distanciaRegistroInicial, vectorParedInicial)).point;
                    Debug.DrawRay(VectorParedSuelo(distanciaRegistroInicial, vectorParedInicial), DireccionParedSuelo(VectorParedSuelo(distanciaRegistroInicial, vectorParedInicial), vectorSueloInicial), Color.green);
                }
                if (RayoParedSuelo(VectorParedSuelo(distanciaRegistroRetroceso, vectorParedInicial)).collider)
                {
                    vectorSueloRetroceso = RayoParedSuelo(VectorParedSuelo(distanciaRegistroRetroceso, vectorParedInicial)).point;
                    Debug.DrawRay(VectorParedSuelo(distanciaRegistroRetroceso, vectorParedInicial), DireccionParedSuelo(VectorParedSuelo(distanciaRegistroRetroceso, vectorParedInicial), vectorSueloInicial), Color.green);
                }

                //Hacer la distancia Pared-Origen y Pared-SueloRetroceso o Pared-SueloInicial. En principio te da igual
                vectorOrigenPared = DistanciaOrigenPared(vectorParedInicial);
                vectorSueloPared = DistanciaSueloPared(vectorSueloInicial,vectorParedInicial);
                anguloRampaNormal = Vector2.Angle(vectorOrigenPared, vectorSueloPared);

                Debug.DrawRay(vectorParedInicial, vectorOrigenPared, Color.magenta);
                Debug.DrawRay(vectorParedInicial, vectorSueloPared, Color.blue);
                Debug.DrawLine(puntoOrigen.position, vectorSueloInicial, Color.white);

                DefinirPared(anguloRampaNormal);
                
            }
        }
        else
        {
            Debug.DrawRay(puntoOrigen.position, DireccionPared(direccionHorizontalNormal), Color.red);
            //identificarPared = IdentificarPared.Default;
        }
    }
    void DefinirAnguloParedEspalda()
    {
        if (RayoPared(direccionHorizontalEspalda))
        {
            Debug.DrawRay(puntoOrigen.position, DireccionPared(direccionHorizontalEspalda), Color.green);
            if (RayoPared(direccionHorizontalEspalda).collider)
            {
                vectorParedInicialEspalda = RayoPared(direccionHorizontalEspalda).point;
                vectorParedRetrocesoEspalda = VectorParedSuelo(distanciaRegistroRetrocesoEspalda, vectorParedInicialEspalda);
                if (RayoParedSuelo(VectorParedSuelo(distanciaRegistroInicialEspalda, vectorParedInicialEspalda)).collider)
                {
                    vectorSueloInicialEspalda = RayoParedSuelo(VectorParedSuelo(distanciaRegistroInicialEspalda, vectorParedInicialEspalda)).point;
                    Debug.DrawRay(VectorParedSuelo(distanciaRegistroInicialEspalda, vectorParedInicialEspalda), DireccionParedSuelo(VectorParedSuelo(distanciaRegistroInicialEspalda, vectorParedInicialEspalda), vectorSueloInicialEspalda), Color.green);
                }
                if (RayoParedSuelo(VectorParedSuelo(distanciaRegistroRetrocesoEspalda, vectorParedInicialEspalda)).collider)
                {
                    vectorSueloRetrocesoEspalda = RayoParedSuelo(VectorParedSuelo(distanciaRegistroRetrocesoEspalda, vectorParedInicialEspalda)).point;
                    Debug.DrawRay(VectorParedSuelo(distanciaRegistroRetrocesoEspalda, vectorParedInicialEspalda), DireccionParedSuelo(VectorParedSuelo(distanciaRegistroRetrocesoEspalda, vectorParedInicialEspalda),vectorSueloInicialEspalda), Color.green);
                }
            }
            vectorOrigenParedEspalda = DistanciaOrigenPared(vectorParedInicialEspalda);
            vectorSueloParedEspalda = DistanciaSueloPared(vectorSueloInicialEspalda, vectorParedInicialEspalda);
            anguloRampaEspalda = Vector2.Angle(vectorOrigenParedEspalda, vectorSueloParedEspalda);

            Debug.DrawRay(vectorParedInicialEspalda, vectorOrigenParedEspalda, Color.magenta);
            Debug.DrawRay(vectorParedInicialEspalda, vectorSueloParedEspalda, Color.blue);
            Debug.DrawLine(puntoOrigen.position, vectorSueloInicialEspalda, Color.white);

            DefinirPared(anguloRampaEspalda);

        }
        else
        {
            Debug.DrawRay(puntoOrigen.position, DireccionPared(direccionHorizontalEspalda), Color.red);
            //identificarPared = IdentificarPared.Default;
        }
    }
    void DefinirPared(float anguloPared)
    {
        //Solo se realiza mientras el rayo toque pared
        if(anguloPared <= anguloLímite)
        {
            Debug.Log("Lo que tienes es una rampa");
            identificarPared = IdentificarPared.Rampa;
        }
        else if(anguloPared > anguloLímite)
        {

            Debug.Log("Lo que tienes es una Pared");
            identificarPared = IdentificarPared.Pared;
        }
    }
    void DefinirSinPared()
    {
        //Si ambos rayos NO estan tocando nada 
        if(!RayoPared(direccionHorizontalNormal) && !RayoPared(direccionHorizontalEspalda))
        {
            Debug.Log("No tienes nada ni enfrente, ni en la espalda");
            identificarPared = IdentificarPared.Default;
        }
    }
    void CambioPropiedadesPlayer()
    {
        switch (identificarPared)
        {
            case IdentificarPared.Pared:
                //En cuanto no detecte una pared, resetea las propiedades
                if (resetPropiedades)
                {
                    jugadorMovimiento.aceleracionBase = aceleracionBaseNormal;
                    jugadorMovimiento.groundLinearDrag = groundLinearDragBaseNormal;
                    resetPropiedades = false;
                }
                break;
            case IdentificarPared.Rampa:
                //En cuanto se detecte una rampa, cambia las propiedades
                if (!resetPropiedades)
                {
                    jugadorMovimiento.aceleracionBase = aceleracionRampa;
                    jugadorMovimiento.groundLinearDrag = groundLinearDragRampa;
                    resetPropiedades = true;
                }
                break;
            case IdentificarPared.Default:
                //Cuando no detectas nada, resetea las propiedades
                if (resetPropiedades)
                {
                    jugadorMovimiento.aceleracionBase = aceleracionBaseNormal;
                    jugadorMovimiento.groundLinearDrag = groundLinearDragBaseNormal;
                    resetPropiedades = false;
                }
                break;
        }
    }
    #region ////Primer Rayo
    /// <summary>
    /// Castea el rayo que detectará si el jugador estará tocando una pared
    /// </summary>
    /// <param name="puntoH">El punto que le da la direccion al rayo</param>
    /// <returns></returns>
    public RaycastHit2D RayoPared(Transform puntoH)
    {
        RaycastHit2D rayoPared;
        return rayoPared = Physics2D.Raycast(puntoOrigen.position, DireccionPared(puntoH), DireccionPared(puntoH).magnitude, pared);
    }
    /// <summary>
    /// Defina la dirección a la que quieres castear el rayo
    /// </summary>
    /// <param name="direccionH">El punto donde quieres que el rayo se dirija</param>
    /// <returns></returns>
    public Vector2 DireccionPared(Transform direccionH)
    {
        Vector2 direccionPared;
        return direccionPared = direccionH.position - puntoOrigen.position;
    }
    #endregion
    #region ///Rayos Vérticales al suelo
    /// <summary>
    /// Lanza un rayo vértical cuyo origen es la pared que toque el rayo
    /// </summary>
    /// <param name="vectorParedSuelo"> Vector que requiere de usar VectorParedSuelo para determinar su origen </param>
    /// <returns></returns>
    public RaycastHit2D RayoParedSuelo(Vector2 vectorParedSuelo)
    {
        RaycastHit2D rayoParedSuelo;
        return rayoParedSuelo = Physics2D.Raycast(vectorParedSuelo, Vector2.down, pared);
    }
    /// <summary>
    /// Se encarga de calcular en donde quieres colocar el origen del rayo vértica para conocer la altura del suelo 
    /// </summary>
    /// <param name="distanciaRegistrada"> La distacia apartir de la cual quieres calcular el punto origen del rayo vértical</param>
    /// <param name="vectorParedBegin">El vector que se registra el rayo por primera vez en la pared</param>
    /// <returns></returns>
    public Vector2 VectorParedSuelo(float distanciaRegistrada, Vector2 vectorParedBegin)
    {
        Vector2 vectorParedSuelo;
        return vectorParedSuelo = new Vector2(vectorParedBegin.x - (distanciaRegistrada * playerPosition.localScale.x) , vectorParedBegin.y);
        //return vectorParedSuelo = new Vector2(vectorParedInicial.x - (distanciaRegistrada * puntoOrigen.localScale.x) , vectorParedInicial.y);
    }
    //ESTO SOLO SIRVE PARA DEBUGEAR EL RAYO DE LA PARED AL SUELO, EL INICIAL
    /// <summary>
    /// Define la direccion del rayo que se crea para que choque con el suelo
    /// </summary>
    /// <param name="distanciaParedSuelo">Se calcula con VectorParedSuelo</param>
    /// <param name="vectorSuelo">El vector que registra el punto del rayo al colisionar contra el suelo</param>
    /// <returns></returns>
    public Vector2 DireccionParedSuelo(Vector2 distanciaParedSuelo, Vector2 vectorSuelo)
    {
        Vector2 direccionParedSuelo;
        //return direccionParedSueloInicial = vectorSueloInicial - VectorParedSuelo();
        return direccionParedSuelo = vectorSuelo - distanciaParedSuelo;
    }
    #endregion
    #region ///Distancia para calcular el ángulo
    /// <summary>
    /// Cálcula la distancia entre el vectorOrigen y la pared que tocaste con el primer rayo
    /// </summary>
    /// <param name="vectorPared">Vector registrado por el rayo al tocar por primera vez la pared</param>
    /// <returns></returns>

    /*
    CALCULA LA DISTANCIA ENTRE LA PARED CON LA QUE CHOCASTE ORIGINALMENTE Y EL PUNTO DE ORIGEN INICIAL
    CALCULA LA DISTANCIA ENTRE LA PARED CON LA QUE CHOCASTE ORIGINALMENTE Y UNO DE LOS PUNTOS DEL SUELO,CUALQUIERA TE SIRVE
    REAILZAS EL CALCULO DE DISTANCIA PARA QUE INTERPRETA EL PUNTO DE LA PARED COMO CENTRO A LA HORA DE CÁLCULAR EL ÁNGULO
    ESTO LO HAGO PORQUE SI COLOCO Vector2.Angle(puntoOrigen, sueloParedInicial) UNITY LO INTERPRETARÁ DESDE EL Vector.Zero, NO CONSEGUIRÍA NADA.     
    */
    public Vector2 DistanciaOrigenPared(Vector2 vectorPared)
    {
        Vector2 distanciaOrigenPared;
        return distanciaOrigenPared = (Vector2)puntoOrigen.position - vectorPared;
        //return distanciaOrigenPared = (Vector2)puntoOrigen.position - vectorParedInicial;
    }
    /// <summary>
    /// Cálcula la distancia del suelo que has registrado y la pared del rayo inicial
    /// </summary>
    /// <param name="vectorSueloI">El vector del primer rayo que toco el suelo</param>
    /// <param name="vectorParedI">El vector del primer rayo que toco la pared</param>
    /// <returns></returns>
    public Vector2 DistanciaSueloPared(Vector2 vectorSueloI, Vector2 vectorParedI)
    {
        Vector2 distanciaSueloPared;
        return distanciaSueloPared = vectorSueloI - vectorParedI;
        //return distanciaSueloPared = vectorSueloInicial - vectorParedInicial;
    }
    #endregion
}