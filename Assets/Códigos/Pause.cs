using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool pausa= false;
    public GameObject pausaUI;
    Rigidbody2D playerRB;
    public GameObject pantallaContoles;

    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pantallaContoles.activeSelf){
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
        pausaUI.SetActive(false);
        pausa = false;
    }

    void Pause1()
    {
        pausaUI.SetActive(true);
        pausa = true;
        Time.timeScale = 0.0f;
    }

    public void QuitarJuego()
    {
        print("*Salir del juego*");
        SceneManager.LoadScene("PantallaDeInicio");
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


