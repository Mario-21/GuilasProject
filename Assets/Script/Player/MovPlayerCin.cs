using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayerCin : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform ubiDirigirPlayer;

    public float horizontalMov;
    public float aceleracion;

    [HideInInspector] public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovCin();
    }
    void MovCin()
    {
        Vector3 movePosition = transform.position;
        movePosition.x = Mathf.MoveTowards(transform.position.x, ubiDirigirPlayer.position.x, horizontalMov * aceleracion * Time.fixedDeltaTime);
        movePosition.y = transform.position.y;
        rb.MovePosition(movePosition);
        AnimacionCaminarPlayer(movePosition.x);
    }
    void AnimacionCaminarPlayer(float objetivo)
    {
        if (transform.position.x < objetivo  || transform.position.x > objetivo)
        {
            anim.SetBool("Walk", true);
        }
        else if (transform.position.x >= objetivo  && transform.position.x <= objetivo)
        {
            anim.SetBool("Walk", false);
        }
    }
}
