using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosCaminar : MonoBehaviour
{
    private PlayerControl playerControl;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && playerControl.estaTocandoPiso && !PlayerControl.agachada)
            audioSource.Play();

    }
}
