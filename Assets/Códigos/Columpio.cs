using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columpio : MonoBehaviour
{
    public GameObject player;
    public Sprite[] MaakuColumpio;
    private bool isTriggered, estaEnColumpio = false;

    void OnTriggerStay2D(Collider2D other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E) && !GameManager.estaMoviendose && !ZoomItem.itemEstaEnZoom)
        {
            if (!estaEnColumpio)
            {
                GameManager.SetInteraccionActivada();
                player.GetComponent<PlayerControl>().enabled = false;
                this.GetComponent<SpriteRenderer>().sprite = MaakuColumpio[0];
                player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
            else
            {
                GameManager.SetInteraccionDesactivada();
                player.GetComponent<PlayerControl>().enabled = true;
                this.GetComponent<SpriteRenderer>().sprite = MaakuColumpio[1];
                player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            }
            estaEnColumpio = !estaEnColumpio;
        }
    }
}
