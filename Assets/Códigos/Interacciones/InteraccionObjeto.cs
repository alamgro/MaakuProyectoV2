using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionObjeto : MonoBehaviour
{
	public bool esParaAbrir; //Determina si el objeto tiene un sprite donde está cerrado (que tiene una interacción que no dropea item)
	public int numDeSecuenciaObj; //Guarda un número que define su lugar dentro de la historia, así solo podrá interactuar con ese item cuando 
	public GameObject boton; //Boton de PressE
	public GameObject itemQueRecoge; //Prefab que cambia el item que recoge
	public Sprite itemQueLoDesbloquea; //Es el item que Maaku necesita tener en el inventario para poder interactuar con este objeto (No siempre aplica)
	public Sprite[] objetoSprites; //Array de sprites para los muebles y objetos de escenario
	public Sprite[] itemSprites; //Array de sprites de los items que puede recoger en este objeto
	[TextArea(2, 4)] //Para ver en el inspector los cuádros de diálogo más grandes
	public string[] dialogosTexto;
	public AudioClip audioSFX;
	int countSprite = 0, countItem = 0, cuentaDialogos;
	private bool isTriggered = false;
	private Inventory inventory;
	private Text dialogo;

	void Start()
	{
		cuentaDialogos = (esParaAbrir || itemQueLoDesbloquea == null) ? 0 : 2; //Controla si el contador de diálogos inicia en 1 o 0 dependiendo de si la variable "esParaAbrir" es true
		cuentaDialogos = (esParaAbrir && itemQueLoDesbloquea != null) ? 2 : cuentaDialogos; //En caso de que se pueda abrir y  necesite un objeto para hacerlo
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		isTriggered = true;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		isTriggered = false;
	}
	void Update()
	{
		if (isTriggered && !GameManager.estaMoviendose && !ZoomItem.itemEstaEnZoom)
		{
			if(itemQueLoDesbloquea != null)
				UsarItemEnObjeto();
			else if (esParaAbrir && numDeSecuenciaObj <= GameManager.secuenciaActual)
				ObjetoQueSeAbre();
			else
				ObjetoQueNoSeAbre();
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

	void ObjetoQueSeAbre() //Cuando el objeto del escenario SÍ tiene una interacción solo para abrirlo (Que no dropea item la primer interacción)
	{
		if (Input.GetKeyDown(KeyCode.E) && countItem < itemSprites.Length) //Si presiona E y aún quedan items disponibles, entonces cambia de sprite
		{
			if (countSprite == 0) //Para la primera vez que interactúa con el objeto (interacción #0)
			{
				SoundScript.playSound(audioSFX); //Audio que se va a reproducir al interactuar la primera vez con el objeto
				this.gameObject.GetComponent<SpriteRenderer>().sprite = objetoSprites[countSprite];
				countSprite++;
			}
			else if (!inventory.isFull) //Para cuando ya pasó de la interacción #0 y verifica si tiene espacio en el inventario
			{
				if (objetoSprites.Length > 1)
				{ //Solo en caso de que el objeto contenga más de un sprite en el array
					this.gameObject.GetComponent<SpriteRenderer>().sprite = objetoSprites[countSprite];
					countSprite++;
				}
				PickItem();
			}
			else if (inventory.isFull)// Muestra un texto indicando que makku no puede cargar mas cosas
			{
				dialogo.text = GameManager.textoInventarioFull;
				GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 7 segundos después.
			}
		}
		else if (countItem == itemSprites.Length) //Cuando ya se acabaron las interacciones, se desbloquean las siguientes secuencias de interacción
		{
			GameManager.secuenciaActual++;
			countItem++;
		}

	}
	void ObjetoQueNoSeAbre() //Cuando el objeto del escenario NO tiene una interacción para abrirlo (Dropea item la primer interacción)
	{
		if (Input.GetKeyDown(KeyCode.E) && !inventory.isFull && numDeSecuenciaObj <= GameManager.secuenciaActual) 
		{
			if (cuentaDialogos < dialogosTexto.Length)
			{
				MostrarDialogos();
			}
			else
			{
				PickItem();
				boton.SetActive(false); //Quitar el botón de la pantalla
				GameManager.SetInteraccionDesactivada();
				GameManager.secuenciaActual++;
				Destroy(this.gameObject);
			}
		}
	}

	/*
	 * El orden de los diálogos par el inspector de este objeto es:
	 * Primer diálogo: lo que Maaku dice cuando no tiene el item correcto en el inventario.
	 * Segundo diálogo:Es el diálogo que Maaku dice cuando ya ha usado el item correcto en este objeto y no quedan más interacciones.
	 * Último diálogo:  Todos los diálogos que el usuario leerá cuando esté interactuando con el objeto (Tiene el item correcto en inventario).
	 */
	void UsarItemEnObjeto()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if (itemQueRecoge.GetComponent<Image>().sprite != itemQueLoDesbloquea && cuentaDialogos < dialogosTexto.Length) //Cuando no tiene el item correcto en inventario.
			{
				dialogo.text = dialogosTexto[0]; //El diálogo en ínidice 0 siempre es el que muestra cuando no tienes el item correcto en inventario.
			}
			//REVISAR AQUÍ SI FALLA ALGO DE LOS DIÁLOGOS (dialogosTexto.Length -1)
			else if (cuentaDialogos < dialogosTexto.Length) //Cuando tiene el item correcto pero tiene que presionar E para que se acaben los diálogos.
			{
				if(esParaAbrir) //Si tiene un sprite para abrir, entonces usarlo
					this.gameObject.GetComponent<SpriteRenderer>().sprite = objetoSprites[0];
				inventory.enabled = false; //Desactiva inventario para que no pueda hacer zoom al objeto del inventario mientras ve los diálogos
				MostrarDialogos();
			}
			else if(cuentaDialogos == dialogosTexto.Length) //Cuando ya han acabado los diálogos y usa el item del inventario
			{
				GameManager.SetInteraccionDesactivada();
				inventory.enabled = true;
				inventory.isFull = false;
				dialogo.text = "You used: " + Inventory.itemActual.GetComponent<Image>().sprite.name;
				cuentaDialogos++;
				boton.SetActive(false);
				GameManager.secuenciaActual++;
				Destroy(Inventory.itemActual);
				SoundScript.playSound(audioSFX);
				PickItem();
			}
			else
			{
				dialogo.text = dialogosTexto[1]; //Diálogo para cuando ya no queden más interacciones con este item
			}
			GameManager.ResetTimer();
		}
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
