using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionALV : MonoBehaviour
{
    public GameObject closet;
    public GameObject Cofre;
    public Text dialogo;
    public GameObject boton;
    public GameObject itemButton;
    public GameObject itemDropeado;
    private Inventory inventory;
    GameObject itemToDelete;
    Collider2D colisionALV;


    int countInteraction = 0;
    bool triggered = false;
    Vector3 posDefault = new Vector3(0, 15, 0);

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = true;
        Vector3 posObjeto = new Vector3(collision.transform.position.x, 3.5f, 0);
        boton.transform.position = posObjeto;
        print(this.name);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        colisionALV = collision;
        triggered = false;
        boton.transform.position = posDefault;
    }

    void CheckInventory()
    {
            if (inventory.isFull == false)
            {
                //Item can be added
                inventory.isFull = true;
                itemToDelete = Instantiate(itemButton, inventory.slots.transform, false);
               
            }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered ) { //Verifica si se presiona E para interactuar

            if (colisionALV.gameObject.name == "Closet" && countInteraction == 0) //Abre el closet
            {
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen1");
                countInteraction++;
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 1 && inventory.isFull == false) //Obtiene las baterías
            {
                dialogo.text = "-Obtuve unas baterías...";
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen2");
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Baterias");
                CheckInventory();
                countInteraction++;
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 2 && inventory.isFull == false) //Obtiene el collar
            {
                colisionALV.gameObject.GetComponent<BoxCollider2D>().enabled = false; //Desactivar el trigger del objeto cuando ya se interactuó
                dialogo.text = "-Obtuve un collar...";
                closet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/ClosetOpen3");
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Collar");
                CheckInventory();
                countInteraction++;
            }
            else if (colisionALV.gameObject.name == "Closet" && countInteraction == 3)
            {
                dialogo.text = "";
            }

            //------------------------------------------Cofre-------------------------------------------

            if (colisionALV.gameObject.name == "CofreClosed") //Abre el cofre
            {
                Cofre.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Muebles/CofreOpen");
                colisionALV.gameObject.name = "CofreOpen";
            }
            else if(colisionALV.gameObject.name == "CofreOpen" && inventory.isFull == false)
            {
                colisionALV.gameObject.GetComponent<BoxCollider2D>().enabled = false; //Desactivar el trigger del objeto cuando ya se interactuó
                dialogo.text = "-Obtuve a Teddy...";
                itemButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Teddy");
                colisionALV.gameObject.name = "CofreOpen*";
                CheckInventory();
            }

            //------------------------------------------------------------------------------------------------------

            if (colisionALV.gameObject.name == "Puerta")
            {

                SceneManager.LoadScene("Patio");
            }
            else if (colisionALV.gameObject.name == "Puerta2")
            {
                SceneManager.LoadScene("Cuarto");
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventory.isFull == true)
            {
                //Item can be added
                inventory.isFull = false;
                itemDropeado.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Items/" + itemButton.GetComponent<Image>().sprite.name);
                Instantiate(itemDropeado, this.transform.position, Quaternion.identity);

                Destroy(itemToDelete);
            }
        }

    }
    

}