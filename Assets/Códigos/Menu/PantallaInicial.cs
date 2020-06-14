using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicial : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarJuego()
    {
        SceneManager.LoadScene("PantallaDeTexto");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    public void QuitarJuego()
    {
        print("Adio popo");
        Application.Quit();
    }
}
