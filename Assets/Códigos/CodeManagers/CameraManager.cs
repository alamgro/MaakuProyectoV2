using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera camara;
    public PolygonCollider2D hab1;
    public PolygonCollider2D hab2;
    public AudioClip audioSFX;
    bool isTriggered = false;
    string habitacion;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        habitacion = collision.name;
        isTriggered = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        habitacion = "";
        isTriggered = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
            if (habitacion.Equals("Puerta1Habitacion1"))
            {
                SoundScript.playSound(audioSFX); //Reproduce sonido
                camara.GetComponent<CinemachineConfiner>().m_BoundingShape2D = hab2;
                camara.GetComponent<CinemachineConfiner>().InvalidatePathCache(); 
                this.transform.position = new Vector3(17.2f, this.transform.position.y, 0);
            }
            else if(habitacion.Equals("Puerta1Habitacion2"))
            {
                SoundScript.playSound(audioSFX); //Reproduce sonido
                camara.GetComponent<CinemachineConfiner>().m_BoundingShape2D = hab1;
                camara.GetComponent<CinemachineConfiner>().InvalidatePathCache(); //Evita que haya bugs al mover el área de confinamiento de la cámara
                this.transform.position = new Vector3(8.0f, this.transform.position.y, 0);
            }

        }

    }
}
