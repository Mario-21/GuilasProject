using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collection_Call : MonoBehaviour
{
    // Start is called before the first frame update
    public int scenaMenuOption;
    public Animator animTransition;
    public void Collection()
    {
        SceneManager.LoadSceneAsync(scenaMenuOption, LoadSceneMode.Additive);
    }
    public void Out_Collection()
    {
        SceneManager.UnloadSceneAsync(scenaMenuOption);
        OutMenuButtons.colliderButtonsStatus = true;
    }
    public void Regret_Menu(string nameAnim)
    {
        animTransition.SetTrigger(nameAnim);
    }
}
