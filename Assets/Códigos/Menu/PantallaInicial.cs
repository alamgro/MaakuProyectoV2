using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaInicial : MonoBehaviour
{
    public GameObject pantallaContoles;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            cerrarControles();
    }

    public void EmpezarJuego()
    {
        SceneManager.LoadScene("PantallaDeTexto");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void QuitarJuego()
    {
        print("Adio popo");
        Application.Quit();
    }

    public void abrirControles() {


        pantallaContoles.SetActive(true);
        
    
    }

    public void cerrarControles() {

        pantallaContoles.SetActive(false);


    }

}
