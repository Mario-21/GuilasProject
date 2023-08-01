using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Ladder_Definition : MonoBehaviour
{
    public enum Type_Ladder
    {
        Wood,
        Steal,
        Rope,
        Default
    }
    public Type_Ladder definitionLadder;
    Stairs_Hidden ladderPlayerControler;

    private void Awake()
    {
        ladderPlayerControler = FindObjectOfType<Stairs_Hidden>();
    }
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerEsta en la escale;");
            switch (definitionLadder)
            {
                case Type_Ladder.Wood:
                    //ladderPlayerControler.ladderSound = FMODEvent.instancia.woodLadder;
                    ladderPlayerControler.laddersSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    ladderPlayerControler.laddersSound.release();
                    ladderPlayerControler.laddersSound = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.woodLadder);
                    break;
                case Type_Ladder.Steal:
                    //ladderPlayerControler.ladderSound = FMODEvent.instancia.stealLadder;
                    ladderPlayerControler.laddersSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    ladderPlayerControler.laddersSound.release();
                    ladderPlayerControler.laddersSound = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.stealLadder);
                    break;
                case Type_Ladder.Rope:
                    //ladderPlayerControler.ladderSound = FMODEvent.instancia.ropeLadder;
                    ladderPlayerControler.laddersSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    ladderPlayerControler.laddersSound.release();
                    ladderPlayerControler.laddersSound = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.ropeLadder);
                    break;
            }
        }
    }
}
