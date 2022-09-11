using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHere))]
public class SameItemCatch: MonoBehaviour
{
    public int indexMod;
    PlayerHere player;
    [Header("Info item")]
    [SerializeField] IncreaseUseItems itemActiveIncrease;
    [SerializeField] Button itemButton;
    [SerializeField] Image colorButton;
    [SerializeField] Text textButton;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseUse();
    }
    void IncreaseUse()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                RestoreButton();
                this.gameObject.SetActive(false);
            }
        }
    }
    void RestoreButton()
    {
        itemButton.enabled = true;
        colorButton.color = new Color(1f, 1f, 1f, 1f);
        textButton.color = new Color(0f, 0f, 0f, 1f);
    }
}
