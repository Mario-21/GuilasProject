using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones_Call : MonoBehaviour
{
    public int scenaMenuOption;
    public Animator animTransition;
    public void Opciones()
    {
        SceneManager.LoadSceneAsync(scenaMenuOption, LoadSceneMode.Additive);
    }
    public void Out_Opciones()
    {
        SceneManager.UnloadSceneAsync(scenaMenuOption);
        OutMenuButtons.colliderButtonsStatus = true;
    }
    public void Regret_Menu(string nameAnim)
    {
        animTransition.SetTrigger(nameAnim);
    }
}
