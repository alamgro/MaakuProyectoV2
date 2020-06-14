using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isFull;
    public GameObject slots;
    public GameObject itemQueSuelta;
    public static GameObject itemActual = null;
    
    //protected PlayerControl playerControl;

    void Start()
    {
        //playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //isFull = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isFull && !ZoomItem.itemEstaEnZoom && !GameManager.estaInteractuando) //Soltar el item del inventaro
        {
            Instantiate(itemQueSuelta, new Vector3(this.transform.position.x, -2.6f, 0.0f), Quaternion.identity);
            Destroy(itemActual);
            isFull = false;
        }

    }
}