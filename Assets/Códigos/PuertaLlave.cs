using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PuertaLlave : MonoBehaviour
{
    private GameObject player;
    public Sprite itemQueLoDesbloquea;
    public GameObject itemQueRecoge;
    public float coordenadaX;
    public float coordenadaY;
    public CinemachineVirtualCamera camara;
    public PolygonCollider2D destino;
    public AudioClip audioSFX;
    bool isTriggered = false;
    private Text dialogo;
    public string[] dialogosTexto;
    public GameObject boton;

    void Start()
    {
        dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        isTriggered = true;
    }
        
    void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered && !ZoomItem.itemEstaEnZoom && !GameManager.estaMoviendose) {
            if (itemQueRecoge.GetComponent<Image>().sprite == itemQueLoDesbloquea)
            {

                SoundScript.playSound(audioSFX); //Reproduce sonido
                camara.GetComponent<CinemachineConfiner>().m_BoundingShape2D = destino;
                camara.GetComponent<CinemachineConfiner>().InvalidatePathCache();
                player.transform.position = new Vector2(coordenadaX, coordenadaY);
                SceneManager.LoadScene("FinalPadres");
            }
            else {
                GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 7 segundos después.
                dialogo.text = dialogosTexto[0];
            }

        }
    }
  
}

