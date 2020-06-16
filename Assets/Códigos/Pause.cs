using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool pausa= false;
    public GameObject pausaUI;
    private PlayerControl playerControl;
    public GameObject pantallaContoles;
    void Start()
    {
      
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (pausa)
            {
                Resume();
            }
            else {
                Pause1();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            cerrarControles();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        playerControl.enabled = true;
        pausaUI.SetActive(false);
        pausa = false;
    }

    void Pause1()
    {
        playerControl.enabled = false;
        pausaUI.SetActive(true);
        pausa = true;
        Time.timeScale = 0.0f;
    }

    public void QuitarJuegop()
    {
        print("*Salir del juego*");
        Application.Quit();
    }


    public void abrirControles()
    {


        pantallaContoles.SetActive(true);


    }

    public void cerrarControles()
    {

        pantallaContoles.SetActive(false);


    }

}


