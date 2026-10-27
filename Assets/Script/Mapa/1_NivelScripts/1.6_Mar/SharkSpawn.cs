using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawn : MonoBehaviour
{
    public bool entryShark;
    public float speed;

    public Transform up;
    public Transform down;
    public Transform spawn;

    public enum EntryOutShark
    {
        up,
        down
    }
    public EntryOutShark up_DownShark;

    BoxCollider2D colliderShark;
    private void Start()
    {
        colliderShark = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (entryShark)
        {
            switch (up_DownShark)
            {
                case EntryOutShark.up:
                    SharkEntry();
                    break;
                case EntryOutShark.down:
                    SharkOut();
                    break;
            }
        }
    }
    void SharkEntry()
    {
        colliderShark.enabled = true;
        if (transform.position.y < up.position.y)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y), new Vector2(transform.position.x, up.transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            entryShark = false;
        }
    }
    void SharkOut()
    {
        colliderShark.enabled = false;
        if (transform.position.y > down.position.y)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, down.transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            entryShark = false;
        }
    }
}
