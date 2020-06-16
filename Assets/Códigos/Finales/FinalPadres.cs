using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalPadres : MonoBehaviour
{
    private Text dialogo;
    public string[] dialogosTexto;
    public GameObject boton;
    public Camera m_OrthographicCamera;
    int cuentaDialogos = 0;
    public AudioClip audioSFX;
    void Start()
    {
       
        dialogo = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
        MostrarDialogos();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cuentaDialogos < dialogosTexto.Length)
            {
                MostrarDialogos();
                SoundScript.playSound(audioSFX);
            }
            
            else if(cuentaDialogos == dialogosTexto.Length)
                SceneManager.LoadScene("Creditos");
        }

        if (cuentaDialogos== 2) {

            m_OrthographicCamera.orthographicSize = 5.3f;
            m_OrthographicCamera.transform.position = new Vector3 (0,0,-10);
           

        }

    }

    void MostrarDialogos()
    {
        
        boton.SetActive(true);
        boton.transform.position = new Vector3(this.transform.position.x, 1.0f, 0);

        GameManager.ResetTimer(); //Reinicia la cuenta de tiempo para borrar el tiempo 7 segundos después.

        dialogo.text = dialogosTexto[cuentaDialogos];
        cuentaDialogos++;
    }
}
