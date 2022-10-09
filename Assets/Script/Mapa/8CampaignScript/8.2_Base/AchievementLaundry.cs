using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLaundry : MonoBehaviour
{
    public int indexCaja;
    public int indexLavadora;
    int once;
    [Header("Cinematic Zone")]
    [SerializeField] GameObject completarLevel;
    [SerializeField] GameObject achievementArea;
    void Update()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexCaja].modificacion && StatusGameobjectsVariables.statusGameobject.modificacion[indexLavadora].modificacion)
        {
            ActiveAchievement();
        }
    }
    void ActiveAchievement()
    {
        if(once < 1)
        {
            completarLevel.SetActive(false);
            achievementArea.SetActive(true);
            once++;
        }
        
    }
}
