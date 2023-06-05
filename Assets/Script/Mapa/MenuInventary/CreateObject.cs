using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [HideInInspector] public GameObject objetoClone;

    Camera cam;

    public bool canDestroyObject;
    public float timeToDestroyClon;
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("CameraDisparo").GetComponent<Camera>();
    }
    void Update()
    {
        if(objetoClone != null)
        {
            objetoClone.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
            //Cuando tengas un objeto o una de dos, no puedes abrir el menu o cuando lo abres el objeto se destruye
        }

        if (Input.GetButtonDown("Fire1"))
        {
            canDestroyObject = true;
        }
        else if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Draw_Weapon"))
        {
            Destroy(objetoClone);
        }

        if (canDestroyObject)
        {
            timeToDestroyClon += Time.deltaTime;
            if(timeToDestroyClon >= 0.05f)
            {
                Destroy(objetoClone);
                timeToDestroyClon = 0;
                canDestroyObject = false;
            }
        }
        
    }
    public void SpawnObjectFromInventory(GameObject objeto)
    {
   
        objetoClone = Instantiate(objeto);
        Inventory.gameIsPause = false;

    }
    public void SpawnItem(GameObject objeto)
    {
        objetoClone = Instantiate(objeto);
        Inventory.gameIsPause = false;
    }
    public void TagSign(string nameTag)
    {
        objetoClone.tag = nameTag;
    }
    public void ChangeSprite (SpriteRenderer spriteItem)
    {
        objetoClone.GetComponent<SpriteRenderer>().sprite = spriteItem.sprite;
    }
    
}
