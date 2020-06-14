using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio_ropa : MonoBehaviour
{
    public GameObject player;
    public AnimatorOverrideController Player_outfit1_sombrero;
    public AnimatorOverrideController Player_outfit1;
    public AnimatorOverrideController Player_outfit2;
    public AnimatorOverrideController Player_outfit2_sombrero;
    public int Contador = 0;
    private bool isTriggered = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered && !GameManager.estaMoviendose && !ZoomItem.itemEstaEnZoom)
            Cambiar_ropa();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
    public void Cambiar_ropa()
    {
        Contador++;
       
        if (Contador == 4)
        {
            Contador = 0;
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit1 as RuntimeAnimatorController;
        }
        if (Contador == 1)
        {

            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit1_sombrero as RuntimeAnimatorController;

        }
        if (Contador == 2)
        {

            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit2 as RuntimeAnimatorController;

        }
        if (Contador == 3)
        {

            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit2_sombrero as RuntimeAnimatorController;

        }
        

    }
}