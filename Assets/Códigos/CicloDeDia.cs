using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDeDia : MonoBehaviour
{
    public GameObject ventana;
    public Sprite[] spritesVentana;

    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4.0f)
        {
            ventana.GetComponent<SpriteRenderer>().sprite = spritesVentana[0];
            timer = 0.0f;
        }
        else if (timer > 2.0f)
            ventana.GetComponent<SpriteRenderer>().sprite = spritesVentana[1];
    }
}
