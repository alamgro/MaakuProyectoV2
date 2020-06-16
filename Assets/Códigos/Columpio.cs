using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columpio : MonoBehaviour
{
    public GameObject player;
    public Sprite MaakuColumpio;
    private bool isTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.E))
        {
            player.SetActive(false);
            this.GetComponent<SpriteRenderer>().sprite = MaakuColumpio;
        }
    }
}
