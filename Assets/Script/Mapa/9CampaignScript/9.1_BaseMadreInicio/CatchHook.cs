using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchHook : MonoBehaviour
{
    bool hook;
    float timeCatchBox;
    [Header("Tipo")]
    public BoxHookType tipoCaja;
    public enum BoxHookType
    {
        CatchBox,
        LeaveBox
    }
    [Header("Box Hook")]
    [SerializeField] BoxCollider2D boxHookCollider;
    [SerializeField] SpriteRenderer boxHookSprite;


    void Update()
    {
        CatchBox();
    }
    void CatchBox()
    {
        if (hook)
        {
            timeCatchBox += Time.deltaTime;
            if(timeCatchBox >= 1.5)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.hookBox);
                switch (tipoCaja)
                {
                    case BoxHookType.CatchBox:  
                        boxHookCollider.enabled = true;
                        boxHookSprite.enabled = true;
                        break;
                    case BoxHookType.LeaveBox:
                        boxHookCollider.enabled = false;
                        boxHookSprite.enabled = false;
                        break;
                }

                hook = false;
                timeCatchBox = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            hook = true;
        }
    }

}
