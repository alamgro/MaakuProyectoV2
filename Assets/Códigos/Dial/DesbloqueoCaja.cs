using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloqueoCaja : MonoBehaviour
{
	public GameObject tv;
	public GameObject UICajaDial;
	public GameObject DialCheck; //Objeto que tiene el script para checar que el código sea correcto
	public int numDeSecuenciaObj;
	public GameObject boton; //Boton de PressE
	public GameObject itemQueRecoge; //Prefab que cambia el item que recoge
	public Sprite itemQueLoDesbloquea; //Es el item que Maaku necesita tener en el inventario para poder interactuar con este objeto (No siempre aplica)
	public Sprite[] objetoSprites; //Array de sprites para los muebles y objetos de escenario
	public Sprite[] itemSprites; //Array de sprites de los items que puede recoger en este objeto
	public string[] dialogosTexto;
	public AudioClip[] audioSFX;//0 cuando esta cerrado y 1 cunado esta abierto 
	public static bool laCajaFueAbieta = false;
	private bool isCompleted = false;
    int countItem = 0, cuentaDialogos = 2;
    private Inventory inventory;
    private Text dialogo;
	private bool isTriggered = false;

    void Start()
    {
		UICajaDial.SetActive(false);
		DialCheck.SetActive(false);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
		itemQueRecoge.GetComponent<Image>().sprite = null;
    }
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.E) && isTriggered && !GameManager.estaMoviendose && cuentaDialogos == dialogosTexto.Length)
        {
			dialogo.text = dialogosTexto[1];
        }
        else if (laCajaFueAbieta && !isCompleted) //Da la señal para que la caja permanezca como abierta y que este puzzle ya se completó
        {
			isCompleted = true;
			AbrirCaja();
        }
		else if (isTriggered && numDeSecuenciaObj <= GameManager.secuenciaActual && PlayerControl.agachada) //El collider está activado y no se ha desbloqueado la caja
        {
			InteractuarConCaja();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //Si presiona Escape o si pone el código correcto, el objeto desaparece del canvas
        {
			SalirDeLaInteraccion(); //Cierra el UI de la caja y lo desactiva del canvas
		}
    }

	void SalirDeLaInteraccion() //Sale de la pantalla de desbloqueo de la caja
    {
		GameManager.SetInteraccionDesactivada();
		boton.SetActive(false);
		PlayerControl.agachada = false;
		inventory.enabled = true;
		UICajaDial.SetActive(false); //desaparece el UI de la caja
		DialCheck.SetActive(false); //El script para checar el código introducido se desactiva
	}

	void InteractuarConCaja()
    {
		if (Input.GetKeyDown(KeyCode.E) && !GameManager.estaMoviendose && !ZoomItem.itemEstaEnZoom)
        {
            if (!inventory.isFull)
            {
				SoundScript.playSound(audioSFX[1]);
				dialogo.text = dialogosTexto[0];
			}
			else if (Inventory.itemActual.GetComponent<Image>().sprite != itemQueLoDesbloquea)
			{ //No tiene el collar para desbloquear la caja
				dialogo.text = dialogosTexto[0]; //El diálogo en ínidice 0 siempre es el que muestra cuando no tienes el item correcto en inventario.
			}
            else if(inventory.isFull && Inventory.itemActual.GetComponent<Image>().sprite == itemQueLoDesbloquea && !laCajaFueAbieta) //Abre la inteacción
            {
				GameManager.SetInteraccionActivada();
				inventory.enabled = false; //Desactivar el inventario para que no pueda abrir el menú de zoom mientras está en esta interacción
				UICajaDial.SetActive(true); //aparece el UI de la caja
				DialCheck.SetActive(true); //El script para checar el código introducido se activa
			}
		}
	}

	void AbrirCaja()
    {
		//Buenas
		tv.GetComponent<SpriteRenderer>().sprite = objetoSprites[0];
		while (cuentaDialogos < dialogosTexto.Length) //Muestra todos los diálogos disp PROBAR 1 Y CON 2 O MÁS
		{
			MostrarDialogos();
		}
		SoundScript.playSound(audioSFX[0]);
		SalirDeLaInteraccion();
		GameManager.secuenciaActual++; //Avanza al secuencia del juego
		Destroy(Inventory.itemActual); //Destruye el objeto que tiene en el inventario (collar)
		PickItem(); //Aparece en su inventario la llave para el Baúl
	}

	void OnTriggerStay2D(Collider2D collision)
    {
		isTriggered = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
		isTriggered = false;
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
