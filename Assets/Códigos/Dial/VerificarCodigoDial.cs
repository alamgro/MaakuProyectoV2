using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerificarCodigoDial : MonoBehaviour
{
    public Button[] boton;
    private string claveCorrecta = "9021";
    private string claveIngresada;

    void Update()
    {
        claveIngresada = "";
        for(int i = 0; i < 4; i++)
        {
            claveIngresada += boton[i].GetComponentInChildren<Text>().text;
        }
        if (claveCorrecta == claveIngresada)
        {
            DesbloqueoCaja.laCajaFueAbieta = true;
        }
    }
}
