using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public Text dialogo;
    
    float timer = 0.0f;
    bool firstCicle = false;
    int count = 0;
    void Start()
    {
        dialogo.text = "-The birds are singing… it’s late.";
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Presionar tecla Espacio para quitar el intro
            count = 3;
        timer += Time.deltaTime;
        if (count == 0) 
            ChangeText("-Where is mom?");
        else if (count == 1)
            ChangeText("-I must go to school...");
        else if (count == 2)
            ChangeText(""); //Evita que la escena interrumpa el conteo anterior
        else if (count == 3)
            SceneManager.LoadScene("Cuarto"); //Cambia a la escena del cuarto
    }

    void ChangeText(string _text)
    {
        if (timer >= 3.0f)
        {
            dialogo.text = _text;
            transitionAnim.SetTrigger("StartAgain");
            timer = 0.0f;
            firstCicle = false;
            count++;
        }
        else if (timer >= 2.0f && !firstCicle)
        {
            firstCicle = true;
            transitionAnim.SetTrigger("End");
        }
    }
}
