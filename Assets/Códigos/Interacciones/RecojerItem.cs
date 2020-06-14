using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecojerItem : MonoBehaviour
{
    private bool isTriggered = false;
    private Inventory inventory;
    public GameObject itemQueRecoge;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true && !inventory.isFull)
        {
            PickItem();
        }
    }

    void PickItem()
    {
        inventory.isFull = true;
        itemQueRecoge.GetComponent<Image>().sprite = this.GetComponent<SpriteRenderer>().sprite;
        Inventory.itemActual = Instantiate(itemQueRecoge, inventory.slots.transform, false);
        this.GetComponent<SpriteRenderer>().sprite = itemQueRecoge.GetComponent<Image>().sprite;
        inventory.itemQueSuelta.GetComponent<SpriteRenderer>().sprite = itemQueRecoge.GetComponent<Image>().sprite;
        Destroy(this.gameObject);
    }
}