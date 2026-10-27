using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhoto : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void EndPhotos()
    {
        animator.SetBool("Picture", false);
    }
}
