using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PisoAscensor : MonoBehaviour
{
    public int indexMod;
    [Header("Password")]
    public string ascensorPassword;
    public int limitPassword;
    int cifrasAscensor;
    [Header("SaveBox UI")]
    [SerializeField] Text textAscensor;
    [SerializeField] Image onPass;
    [Header("CompletePassword")]
    [SerializeField] GameObject p3;
    [SerializeField] GameObject p3Cifras;
    [Header("Camera Shake")]
    [SerializeField] CinemachineVirtualCamera mainCamera;
    public float magnitudAscensor;
    [Header("Player Move")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;

    bool passwordOn;

    [Header("Pisos Botones")]
    [SerializeField] GameObject pisos;
    [Header("Cifras")]
    [SerializeField] GameObject cifras;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            AscensorCorrect();
        }
    }
    void Update()
    {
        ActivePanelAscensor();
        //AnalisisPassword();
    }
    #region BotonesPulsar

    public void GoPiso(int piso)
    {
        Debug.Log("Escena Piso");
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.buttonAscensor_UI);
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.ascensorAction);
        EstructuraNiveles.nivel = piso;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        bloqPlayer.BloquearMovPlayer();
        mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitudAscensor;
    }
    public void SpawnPiso (int spawn)
    {
        Debug.Log("Spawn Piso");
        CheckPointController.numeroCheckPoint = spawn;
    }
    public void ActiveWritePassWord()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.buttonAscensor_UI);
        passwordOn = !passwordOn;
    }
    public void ColocarNum(int num)
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.buttonAscensor_UI);
        if (textAscensor.text.Length < limitPassword)
        {
            textAscensor.text += num.ToString();
            cifrasAscensor++;
        }
        else if (textAscensor.text.Length >= limitPassword)
        {
            Debug.Log("Fal");
            //Si por casualidad tienen el mismo numero sustituira tambien el mismo numero
            textAscensor.text = textAscensor.text.Remove(textAscensor.text.Length - 1);
            textAscensor.text += num.ToString();
        }
        //CUando borres la tecla hay que saber cual es la ultima de la ultima. si borras la segunda, luego borra la primera
    }
    public void DeleteNum()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.retrocerder_UI);
        if (textAscensor.text.Length > 0)
        {
            textAscensor.text = textAscensor.text.Remove(textAscensor.text.Length - 1);
            cifrasAscensor--;
        }
    }

    #endregion

    #region CheckContraseña
    void ActivePanelAscensor()
    {
        if (passwordOn)
        {
            pisos.SetActive(false);
            cifras.SetActive(true);
        }
        else
        {
            pisos.SetActive(true);
            cifras.SetActive(false);
            onPass.color = Color.white;
            //Resetea el panel
            textAscensor.text = "";
            cifrasAscensor = 0;
        }
    }

    void AnalisisPassword()
    {
        if (textAscensor.text.Length >= limitPassword)
        {
            CheckAscensor();
        }
    }
    void CheckAscensor()
    {
        if(textAscensor.text == ascensorPassword.ToString())
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.confirm_UI);
            AscensorCorrect();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            onPass.color = Color.green;
            passwordOn = false;
        }
        else
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.error_UI);
            textAscensor.text = "";
            cifrasAscensor = 0;
            onPass.color = Color.red;
        }
    }
    void AscensorCorrect()
    {
        p3.SetActive(true);
        p3Cifras.SetActive(true);
    }
    #endregion
}
