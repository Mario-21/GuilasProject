using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDrink : MonoBehaviour
{
    public int indexMod;
    public int indexAspersor;

    [Header("Poison Enemy Data")]
    [SerializeField] GameObject enemyPoison;
    [SerializeField] GameObject cadaver;
    public float poisonSceneLimit;
    public float cadaverSceneLimit;

    [Header("Action Drink")]
    [SerializeField] Transform brazoSoldier;
    public float timeRotateLimit;
    public float timeRotate;

    [Header("Soldados Help")]
    [SerializeField] List<SoldadoNormal> soldadosHelp;
    [SerializeField] int indexSoldado1;
    [SerializeField] int indexSoldado2;

    [Header("Player Help")]
    [SerializeField] GameObject doorBañoClose;
    [SerializeField] GameObject doorBañoOpen;
    [SerializeField] UseCin endCin;

    [Header("Player Time")]
    public float timePlayerLimit;
    float timePlayer;

    public float timeScene;
    enum SecuenciaPoison
    {
        DrinkPoison,
        PoisonCadaver,
        Help
    }
    SecuenciaPoison poisonScene;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PoisonCin();
    }
    void PoisonCin()
    {
        switch (poisonScene)
        {
            case SecuenciaPoison.DrinkPoison:
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //Bebe el veneno
                DrinkPoison();
                timeScene += Time.deltaTime;
                //Pasado un tiempo transicion y cambio de escena
                if(timeScene >= poisonSceneLimit)
                {
                    AnimationHud.detectar_echar.SetBool("Transicion", true);
                    poisonScene = SecuenciaPoison.PoisonCadaver;
                    timeScene = 0;
                }
                break;
            case SecuenciaPoison.PoisonCadaver:
                //Colocas el Cadaver
                timeScene += Time.deltaTime;
                if (timeScene >= cadaverSceneLimit)
                {
                    enemyPoison.SetActive(false);
                    cadaver.SetActive(true);
                    poisonScene = SecuenciaPoison.Help;
                }
                break;
            case SecuenciaPoison.Help:
                SoldierHelp();
                break;
        }
    }
    void DrinkPoison()
    {
        if (timeRotate < timeRotateLimit)
        {
            //Bebe La bebida
            timeRotate += Time.deltaTime;
            brazoSoldier.Rotate(0f, 0f, 1f);
        }
    }
    void SoldierHelp()
    {
        //Si no se ha activado el aspersor, pueden venir ayudarle. Además de tener que estar los 2 vivos.
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexAspersor].modificacion)
        {
            //Si ambos viven, ellos le ayudan
            if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldado1].statusVida > 0 &&
               SoldierActiveInScene.instancia.soldiersStatus[indexSoldado2].statusVida > 0)
            {
                AnimationHud.detectar_echar.SetBool("Transicion", true);
                foreach (SoldadoNormal soldado in soldadosHelp)
                {
                    soldado.enabled = true;
                }
                this.enabled = false;
            }
            //En caso de morir le ayuda el Player
            else
            {
                AnimationHud.detectar_echar.SetBool("Transicion", false);
                PlayerHelp();
                
            }
        }
        else
        {
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            PlayerHelp();
        }

        //Si estan los dos soldados muertos y no se han activado los aspersores, entonces el Player entrara en accion
    }
    void PlayerHelp()
    {
        //Sonido puerta abriendose
        doorBañoClose.SetActive(false);
        doorBañoOpen.SetActive(true);
        

        timePlayer += Time.deltaTime;
        if (timePlayer >= timePlayerLimit)
        {
            endCin.UseCinematic();
            this.enabled = false;
        }
    }
}
