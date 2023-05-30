using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialesDeath : MonoBehaviour
{
    public Animator tutorialAnim;

    public float timeLiveLimit;
    float timeLive;
    private void Start()
    {
        tutorialAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(timeLive >= timeLiveLimit)
        {
            tutorialAnim.SetTrigger("Goodbye");
        }
        else
        {
            timeLive += Time.deltaTime;
        }
    }
    public void TutorialDeath()
    {
        Destroy(this.gameObject);
    }
    private void OnEnable()
    {
        TutoControlerInGame.tutoActive = true;
        TutoControlerInGame.tutoActual = this.gameObject;
    }
    private void OnDisable()
    {
        TutoControlerInGame.tutoActive = false;
    }
}
