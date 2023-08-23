using UnityEngine;

public class BellSound : MonoBehaviour
{
    public int indexMod;
    bool bellSound;

    int soundOnlyOne;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) BellRest();
    }
    void BellRest()
    {
        if (bellSound)
        {
            if(soundOnlyOne < 1)
            {
                //Reproduce the audioCLip BellSound only once 
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.bell);
                soundOnlyOne++;
            }
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) bellSound = true;
    }
}
