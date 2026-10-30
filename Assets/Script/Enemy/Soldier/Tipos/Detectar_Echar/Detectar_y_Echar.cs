using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectar_y_Echar : MonoBehaviour
{
    [Header("Menu Player")]
    [SerializeField] Inventory menuPlayer;
    [Header("Player Data")]
    JugadorMovimiento movPlayer;
    [SerializeField] BloquearMovimientoPlayer player;
    [Header("Enemy Data")]
    public SoldadoNormal soldier;
    public GameObject brazoNormal;
    public GameObject brazoAccion;
    [Header("Scene")]
    public int sceneReload;
    public string escenaNombreRecarga;
    public int spawn;

    bool evento;
    bool balaInside;

    //ObjetoInteractivo objInter;

    enum SecuenceDetect
    {
        girarSoldado,
        showDialogo,
        resetScene

    }
    SecuenceDetect detectScene;


    float timeDialogo;
    int reactivateInventory;
    private void Awake()
    {
        movPlayer = FindObjectOfType<JugadorMovimiento>();
        //objInter = GetComponent<ObjetoInteractivo>();
    }
    private void Start()
    {
        VisionSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        //Change the script: SoldadoDet/Echar out, now you have the same script in all soldier, but with
        //the difference that soldier with trigger will have low range
        //Hacer script aditional con la rama nivel 2 si el estatus es true destruye esto
        if (evento && !soldier.berserker && soldier.GetComponent<SoldierLife>().vida > 0 && !balaInside) 
        {
            Secuence();
        }
        if (soldier.GetComponent<SoldierLife>().vida <= 0 || soldier.berserker) 
        {
            if(reactivateInventory < 1)
            {
                menuPlayer.enabled = true;
                reactivateInventory++;
            }
            Destroy(this);
            player.HabilitarMovPlayer();
        }
        if(soldier.GetComponent<SoldierLife>().vida > 0)
        {
            VisionSwitch();
        }
        else if (soldier.GetComponent<SoldierLife>().vida <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
    }
    public void Secuence()
    {
        switch (detectScene)
        {
            case SecuenceDetect.girarSoldado:
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.detect_NormalMode);
                //Inhabilita mi inventario
                menuPlayer.enabled = false;
                menuPlayer.inventory.SetActive(false);
                //Desactiva animacion y IA del Enmeigo 
                soldier.enabled = false;
                soldier.OutAnimation();
                //El enemigo se gire izq.
                if (ScaleWithDistance().x < 0) soldier.transform.localScale = new Vector3(-1f, 1f, 1f);
                //El enemigo gire drcha.
                else if (ScaleWithDistance().x > 0) soldier.transform.localScale = new Vector3(1f, 1f, 1f);
                //Colocar Nivel
                EstructuraNiveles.nivel = sceneReload;
                EstructuraNiveles.nombreNivel = escenaNombreRecarga;
                if (!balaInside) detectScene = SecuenceDetect.showDialogo;
                break;
            case SecuenceDetect.showDialogo:
                brazoNormal.SetActive(false);
                brazoAccion.SetActive(true);
                timeDialogo += Time.deltaTime;
                if (timeDialogo >= 1) 
                {
                    Debug.Log("Colocar dialogo"); //objInter.DetenerDialogo();
                    detectScene = SecuenceDetect.resetScene;
                }
                if (timeDialogo >= 2) Debug.Log("Final dialogo 2");//detectScene = SecuenceDetect.resetScene;
                break;
            case SecuenceDetect.resetScene:
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                CheckPointController.numeroCheckPoint = spawn;
                break;
        }
    }
    void VisionSwitch()
    {
        //En cuanto el soldado entre en modo ataque, el rango de visión se intercambiará del cuadrado al cono.
        if (soldier.berserker)
        {
            soldier.visionItemRange.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("vision detector Desactivo");
            soldier.visionItemRange.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer")) balaInside = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (movPlayer.onGround && collision.gameObject.CompareTag("Player") || player.stairs_Hidden.escalar && collision.gameObject.CompareTag("Player"))
        {
            evento = true;
            if(!balaInside && !ArmaController.preCollisionObject)player.BloquearMovPlayer();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer")) balaInside = false;
    }

    Vector2 ScaleWithDistance()
    {
        Vector2 distancePlayerSoldier;
        return distancePlayerSoldier = movPlayer.transform.position - soldier.transform.position;
        
    }
}
