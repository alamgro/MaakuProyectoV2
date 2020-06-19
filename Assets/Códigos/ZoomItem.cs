using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomItem : MonoBehaviour
{
    public static Sprite itemParaHacerZoom;
    private GameObject UIitemZoom;
    private GameObject UIRecuadroZoom;
    private Inventory inventory;
    public static bool itemEstaEnZoom = false;

    // Start is called before the first frame update
    void Start()
    {
        UIRecuadroZoom = GameObject.FindGameObjectWithTag("RecuadroZoom");
        UIitemZoom = GameObject.FindGameObjectWithTag("Zoom");
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab) && inventory.isFull && !GameManager.estaMoviendose && !GameManager.estaInteractuando && !Pause.pausa) //Hacer zoom al objeto del inventario
        {
            if (!itemEstaEnZoom) //&& GameManager.menuAbierto == false
            {
                UIRecuadroZoom.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                UIitemZoom.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
                UIitemZoom.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                //GameManager.menuAbierto = true;
            }
            else
            {
                UIRecuadroZoom.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                UIitemZoom.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                //GameManager.menuAbierto = false;
            }
            itemEstaEnZoom = !itemEstaEnZoom;
        }
    }
}
