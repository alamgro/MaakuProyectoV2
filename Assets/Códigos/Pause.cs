using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pausa= false;
    public GameObject pausaUI;
    private Inventory inventory;
    private PlayerControl playerControl;
     void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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

}


