using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static bool puedeInteractuar = false; 
    //public static bool menuAbierto = false;
    public Text dialogo;
    public static float timer = 0.0f;
    public static float timerInteraccion = 0.0f;
    public static float tiempoSinMoverse = 0.0f;
    public static bool triggerBorrarTexto = false;
    public static int secuenciaActual = 0; //Marca el progreso del juego
    public static bool estaMoviendose = false;
    public static bool estaInteractuando = false;
    public static string textoInventarioFull = "- I can't carry anything else!";
    private PlayerControl playerControl;
    public static void SetInteraccionActivada()// Indica que el jugador ya esta interactuando y presionando E
    {
        GameManager.estaInteractuando = true;
        PlayerControl.precionaE = true;
    }
    public static void SetInteraccionDesactivada()// Indica que el jugador ya no esta interactuando ni presionando E
    {
        GameManager.estaInteractuando = false;
        PlayerControl.precionaE = false;
    }

    public static void VocesEnLaCabeza(AudioClip audioSFX) //Si Maaku deja de moverse por 20 segundos, escuchará voces
    {
        tiempoSinMoverse += Time.deltaTime;
        if(tiempoSinMoverse >= 2990.0f) //Cambiar a 20 seg
        {
            tiempoSinMoverse = 0.0f;
            SoundScript.playSound(audioSFX);
        }
    }

    public static void ResetTimer()
    {
        timer = 0.0f;
        triggerBorrarTexto = true;
    }
    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
    void Update()
    {
        if(triggerBorrarTexto) // Si el diálogo es diferente a vacío, entonces empieza contar 7 segundos para borrar el texto
        {
            timer += Time.deltaTime;
            if (timer >= 7.0f)
            {
                dialogo.text = "";
                timer = 0.0f;
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || !playerControl.estaTocandoPiso)
        {
            estaMoviendose = true; //Si cualquierad de estás condiciones se cumple, significa que Maaku se está moviendo
        }
        else
        {
            estaMoviendose = false; //Si ninguna condición se cumple, la variable toma valor de FALSE
        }
        print(secuenciaActual);
    }
}