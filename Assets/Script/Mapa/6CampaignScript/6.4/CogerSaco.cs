using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CogerSaco : MonoBehaviour
{
    bool catchBag;
    [Header ("Soldier Info")]
    [SerializeField] SoldierLife vidaSoldier;
    [SerializeField] List<GameObject> itemToCatch;
    int indexItemCatch;
    public string nameSoldier;
    [Header("Time to take an action")]
    public float timeToCatchLimit;
    public float timeToTakeBag;
    float timeToCatch;
    
    public enum ActionBags
    {
        Leave_bag,
        Put_bag
    }
    [Header("What action")]
    public ActionBags soldierAction;

    [Header("SFX Agarrar")]
    [SerializeField] EventReference agarrar;
    StudioEventEmitter emissorEffect;
    [SerializeField] GameObject emisorCarreta;

    private void Start()
    {
        emissorEffect = AudioManager.instancia.InitializeEventEmitter(agarrar, emisorCarreta);
    }
    // Update is called once per frame
    void Update()
    {
        PickUpBag();
    }
    void PickUpBag()
    {
        if(vidaSoldier.vida > 0)
        {
            if (catchBag)
            {
                timeToCatch += Time.deltaTime;
                if (timeToCatch >= timeToCatchLimit && indexItemCatch < itemToCatch.Count)
                {
                    switch (soldierAction)
                    {
                        case ActionBags.Leave_bag:
                            itemToCatch[indexItemCatch].SetActive(false);
                            break;
                        case ActionBags.Put_bag:
                            itemToCatch[indexItemCatch].SetActive(true);
                            break;
                    }
                    emissorEffect.Play();
                    indexItemCatch++;
                    timeToCatch = 0;
                }
                else if  (indexItemCatch >= itemToCatch.Count)
                {
                    catchBag = false;
                    indexItemCatch = 0;
                }
            }
            else timeToCatch = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == nameSoldier)
        {
            catchBag = true;
            vidaSoldier.GetComponent<SoldadoNormal>().maxTiempoUbi = timeToTakeBag;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == nameSoldier)
        {
            catchBag = false;
        }
    }
}
