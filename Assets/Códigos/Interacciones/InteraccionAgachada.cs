using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionAgachada : MonoBehaviour
{
	int countItem = 0, cuentaDialogos = 0;
	public int numDeSecuenciaObj; //Guarda un número que define su lugar dentro de la historia, así solo podrá interactuar con ese item cuando 
	public string[] dialogosTexto;
	public GameObject boton; //Boton de PressE
	public GameObject itemQueRecoge; //Prefab que cambia el item que recoge
	public Sprite[] itemSprites; //Array de sprites de los items que puede recoger en este objeto
	public AudioClip audioSFX;
	private bool isTriggered = false;
	private Inventory inventory;
	private Text dialogo;
	private void Start()
	{
		
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
	}

	void Update()
	{
		if (PlayerControl.agachada)
			ObjetoAgachada();
		else if(Input.GetKeyDown(KeyCode.E) && isTriggered)
			dialogo.text = "Uh! I think there is something under the coach.";
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		isTriggered = true;
	}
	void OnTriggerExit2D(Collider2D collision)
	{
		isTriggered = false;
	}

	void ObjetoAgachada()
    {
		if (Input.GetKeyDown(KeyCode.E) && !GameManager.estaMoviendose && !ZoomItem.itemEstaEnZoom && !inventory.isFull && numDeSecuenciaObj <= GameManager.secuenciaActual && isTriggered)
		{
			if (cuentaDialogos < dialogosTexto.Length)
			{
				MostrarDialogos();
			}
			else
			{
				SoundScript.playSound(audioSFX);
				PlayerControl.agachada = false;
				PickItem();
				boton.SetActive(false); //Quitar el botón de la pantalla
				GameManager.SetInteraccionDesactivada();
				Destroy(this.gameObject);
			}
		}
	}
	void PickItem() //Recoge el item
	{
		inventory.isFull = true;
		itemQueRecoge.GetComponent<Image>().sprite = itemSprites[countItem];
		Inventory.itemActual = Instantiate(itemQueRecoge, inventory.slots.transform, false);
		inventory.itemQueSuelta.GetComponent<SpriteRenderer>().sprite = itemQueRecoge.GetComponent<Image>().sprite; //Le decimos cuál item debería soltar en caso de que presione 1
		countItem++;
	}
	void MostrarDialogos()
	{
		GameManager.SetInteraccionActivada();
		boton.SetActive(true);
		boton.transform.position = new Vector3(this.transform.position.x, 3.5f, 0);

		GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 7 segundos después.

		dialogo.text = dialogosTexto[cuentaDialogos];

		cuentaDialogos++;
	}
}
//-I drew my first day of school.
// -I love my backpack, is so pretty and Pink.
