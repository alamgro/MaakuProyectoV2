using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    float moveSpeed;
    public string escena;
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Colisión");
        SceneManager.LoadScene("PantallaDeInicio");   
    }
    void Start()
    {
        moveSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
