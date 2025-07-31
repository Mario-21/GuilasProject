using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bata_Player : MonoBehaviour
{
	[Header("Datos Horizontal Bata")]
    [SerializeField] JugadorMovimiento playerMov;
	[SerializeField] ArmaController arma;
	[Header("Datos Brazo Bata")]
	[SerializeField] PutGasMask mascaraBata;
	[SerializeField] SpriteRenderer brazoPlayer;
	[SerializeField] Sprite brazoBata;
	[SerializeField] Sprite brazoPasivo;
    Animator animBata;
    void Start()
    {
        animBata = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if(playerMov.horizontalMov != 0)
		{
			//Si me estoy moviendo
			animBata.SetBool("BataCaminar", true);
			//Sino estoy apuntando
			if (!arma.activarDisparo)
			{
				//Mirar Izquierda o Derecha
				if (playerMov.myTransform.localScale.x == -1 || playerMov.myTransform.localScale.x == 1)
				{
					animBata.SetBool("Seguir", true);
				}

			}
			else
			{
				//Si estoy apuntando y el personaje retrocede
				if ((playerMov.myTransform.localScale.x == -1 && playerMov.horizontalMov == 1) || (playerMov.myTransform.localScale.x == 1 && playerMov.horizontalMov == -1))
				{
					animBata.SetBool("Seguir", false);
				}
				//Si apunto y me voy hacía delante
				else if ((playerMov.myTransform.localScale.x == 1 && playerMov.horizontalMov == 1) || (playerMov.myTransform.localScale.x == -1 && playerMov.horizontalMov == -1))
				{
					animBata.SetBool("Seguir", true);
				}
			}
		}
		else if(playerMov.horizontalMov == 0)
		{
			animBata.SetBool("BataCaminar", false);
		}
		// Cambiar Brazo del Player
		if (mascaraBata.putMask)
		{
			brazoPlayer.sprite = brazoBata;
		}
		else
		{
			brazoPlayer.sprite = brazoPasivo;
		}
	}
}
