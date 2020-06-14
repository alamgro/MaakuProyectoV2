using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarElPiso : MonoBehaviour
{

    private PlayerControl player;
    void Start()
    {
        player = GetComponentInParent<PlayerControl>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag ("piso"))             
        {
            player.estaTocandoPiso = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag ("piso"))
        {
             player.estaTocandoPiso = false;
            
        }
    }
}
