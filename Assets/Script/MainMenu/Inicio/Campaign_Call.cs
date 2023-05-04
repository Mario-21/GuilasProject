using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Campaign_Call : MonoBehaviour
{
    public int scenaMenuCampaign;
    public Animator animTransition;

    //Ir a la pantalla de la campaña
    public void Campaign()
    {
        SceneManager.LoadSceneAsync(scenaMenuCampaign, LoadSceneMode.Additive);
    }
    //Descarga la pantalla
    public void Out_Campaign()
    {
        SceneManager.UnloadSceneAsync(scenaMenuCampaign);
        OutMenuButtons.colliderButtonsStatus = true;
    }
    //Llamar a la animacion para salir de la campaña
    public void Regret_Menu(string nameAnim)
    {
        animTransition.SetTrigger(nameAnim);
    }
}
