using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Puerta : MonoBehaviour
{
    private GameObject player;
    public float coordenadaX;
    public float coordenadaY;
    public CinemachineVirtualCamera camara;
    public PolygonCollider2D destino;
    public AudioClip audioSFX;
    bool isTriggered = false;
   

    // Start is called before the first frame update
    void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered && !ZoomItem.itemEstaEnZoom)
        {
            print("Estoy entrando men");
            SoundScript.playSound(audioSFX); //Reproduce sonido
            camara.GetComponent<CinemachineConfiner>().m_BoundingShape2D = destino;
            camara.GetComponent<CinemachineConfiner>().InvalidatePathCache();
            player.transform.position = new Vector2(coordenadaX, coordenadaY);
        }
    }
}
