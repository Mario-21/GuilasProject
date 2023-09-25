using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POV : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera pruebaCamera;
    public Transform mira;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mira.position = pruebaCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -pruebaCamera.transform.position.z));
    }
}
