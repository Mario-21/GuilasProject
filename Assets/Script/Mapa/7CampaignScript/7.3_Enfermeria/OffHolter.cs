using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffHolter : MonoBehaviour
{
    PlayerHere player;

    public GameObject holterEffect;

    public bool onHolter;
    private void Start()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        if (player.playerImHere) ActiveHolter();
    }
    void ActiveHolter()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            onHolter = !onHolter;
        }
        OnHolter();
    }
    void OnHolter()
    {
        if (onHolter)
        {
            holterEffect.SetActive(true);
        }
        else
        {
            holterEffect.SetActive(false);
        }
    }
}
