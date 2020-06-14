using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionSoloDialogo : MonoBehaviour
{
    public Text UIDialogo;
    [TextArea(2, 4)] //Para ver en el inspector los cuádros de diálogo más grandes
    public string[] textoDialogo;
    public GameObject boton; //Boton de PressE
    private bool isTriggered = false;
    private int count = 0;
    private PlayerControl playerControl;

    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		boton.SetActive(true);
        boton.transform.position = new Vector3(this.transform.position.x, 3.5f, 0);
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
            Interactuar();
        }
    }

    void Interactuar()
    {
        if (Input.GetKeyDown(KeyCode.E) && count < textoDialogo.Length)
        {
            GameManager.SetInteraccionActivada();
            GameManager.ResetTimer();
            UIDialogo.text = textoDialogo[count];
            count++;
        }
        else if (count == textoDialogo.Length) //Cuenta para saber si ya ha leído todos los diálogos
        {
            GameManager.SetInteraccionDesactivada();
            GameManager.secuenciaActual++;
            boton.SetActive(false);
            count++;
        }
    }
}
