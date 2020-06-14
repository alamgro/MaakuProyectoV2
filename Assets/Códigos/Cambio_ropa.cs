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


    public void Cambiar_ropa()
    {
        Contador++;
        print(Contador);
        if (Contador == 5)
        {
            Contador = 0;

        }
        if (Contador == 1)
        {
            print("hola1");
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit1 as RuntimeAnimatorController;

        }
        if (Contador == 2)
        {
            print("hola2");
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit1_sombrero as RuntimeAnimatorController;

        }
        if (Contador == 3)
        {
            print("hola3");
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit2 as RuntimeAnimatorController;

        }
        if (Contador == 4)
        {
            print("hola4");
            player.GetComponent<Animator>().runtimeAnimatorController = Player_outfit2_sombrero as RuntimeAnimatorController;

        }

    }
}