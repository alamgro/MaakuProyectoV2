using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class PlayerControl : MonoBehaviour
{
    public AudioClip audioSFX;
    private Rigidbody2D rb;
    private Animator animar;
    private SpriteRenderer sprite;
    public float vmax = 20f;
    public float vel = 20f;
    public bool estaTocandoPiso;
    public static bool agachada;
    public bool iniciarSalto;
    public float poder_salto = 6.5f;
    private bool saltar;
    public static bool precionaE;
    float momentoInicilizarBrinco = 0.0f;
    float InicializarCaminar = 0.0f;
    float duracionEspera = 0.45f;
    float duracionEspera2 = 0.8f;
    float duracionEspera3 = 0.8f;
    public bool puedeCaminar;
    public bool puedeCaminar2;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animar = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animar.SetFloat("velocidad", Mathf.Abs(rb.velocity.x));
        animar.SetBool("piso", estaTocandoPiso);

        if (Input.GetKeyDown(KeyCode.W) && estaTocandoPiso && agachada == false && precionaE == false)// al presionar salta
        {
            momentoInicilizarBrinco = Time.time + duracionEspera;
            saltar = true;

        }
        else if (Input.GetKeyDown(KeyCode.S) && precionaE == false && saltar == false && estaTocandoPiso == true) // mientras este apretada se agacha y no se puede mover
        {
            agachada = true;
            puedeCaminar = false;
            vel = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.S) && !GameManager.estaInteractuando) // al soltarla se levanta y puede volver a moverse
        {
            agachada = false;
            InicializarCaminar = Time.time + duracionEspera2;
        }
        else if (Input.GetKeyDown(KeyCode.E) && agachada == false && saltar == false) // se activa animacion de agarrar algo
        {
            precionaE = true;
            puedeCaminar2 = false;
            vel = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.E) && !GameManager.estaInteractuando) // se desactiva animacion de agarrar algo
        {
            precionaE = false;
            InicializarCaminar = Time.time + duracionEspera3;

        }
        else if (puedeCaminar == false)
        {
            if (agachada == false)
            {
                if (Time.time >= InicializarCaminar)
                {
                    vel = 5f;
                    puedeCaminar = true;
                }
            }
        }
        else if (puedeCaminar2 == false)
        {
            if (precionaE == false)
            {
                if (Time.time >= InicializarCaminar)
                {
                    vel = 5f;
                    puedeCaminar = true;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (saltar)
        {
            iniciarSalto = true;
            vel = 0f;
            if (Time.time >= momentoInicilizarBrinco)
            {
                vel = 5f;
                rb.AddForce(Vector2.up * poder_salto, ForceMode2D.Impulse);
                saltar = false;
                iniciarSalto = false;
            }
        }
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(vel * h, rb.velocity.y);

        if (iniciarSalto)
            animar.SetBool("iniciarSalto", iniciarSalto);
        else
            animar.SetBool("iniciarSalto", iniciarSalto);

        if (agachada)
            animar.SetBool("agachada", agachada);
        else
            animar.SetBool("agachada", agachada);

        if (precionaE)
            animar.SetBool("precionaE", precionaE);
        else
            animar.SetBool("precionaE", precionaE);

        if (h > 0.1f) // voltea la animacion segun se necesite.
        {
            sprite.flipX = false;
        }

        if (h < -0.1f)
        {
            sprite.flipX = true;
        }
    }
}