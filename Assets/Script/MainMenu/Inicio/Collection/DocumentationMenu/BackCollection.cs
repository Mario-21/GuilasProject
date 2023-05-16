using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCollection : MonoBehaviour
{
    public int backCollection;
    public void BackColection()
    {
        CollectionDirection.posFila = backCollection;
        CollectionDirection.repostDocs = true;
    }
}
