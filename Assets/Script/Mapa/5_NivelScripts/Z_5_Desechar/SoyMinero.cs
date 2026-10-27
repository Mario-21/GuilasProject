using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoyMinero : MonoBehaviour
{
    [SerializeField] PutGasMask haveMask;
    [SerializeField] List<Detectar_y_Echar> detectoresEnemys;
    [SerializeField] List<BoxCollider2D> colliderDetectores;
    int breakloop_Mask;
    int breakloop_NoMask;
    void Start()
    {
        //YaNoSoyMinero();
    }

    // Update is called once per frame
    void Update()
    {
        SerMinero_NoSerMinero();
    }
    void SerMinero_NoSerMinero()
    {
        //Chage tag for not detected
        //If I put on the mask
        if (haveMask.putMask)
        {
            breakloop_NoMask = 0;
            if (breakloop_Mask < detectoresEnemys.Count) 
            {
                for (int i = 0; i < detectoresEnemys.Count; i++)
                {
                    detectoresEnemys[i].enabled = false;
                    colliderDetectores[i].enabled = false;
                    Debug.Log("Se ha desactivado los detectores " + i);
                    breakloop_Mask++;
                }
            }
        }
        else
        {
            breakloop_Mask = 0;
            if(breakloop_NoMask < detectoresEnemys.Count)
            {
                for (int i = 0; i < detectoresEnemys.Count; i++)
                {
                    detectoresEnemys[i].enabled = true;
                    colliderDetectores[i].enabled = true;
                    Debug.Log("Se ha reactivado los detectores " + i);
                    breakloop_NoMask++;
                }
            }
        }
    }
    void YaNoSoyMinero()
    {
        if (!haveMask.putMask)
        {
            for (int i = 0; i < detectoresEnemys.Count; i++)
            {
                detectoresEnemys[i].enabled = true;
                
            }
        }
    }
}
