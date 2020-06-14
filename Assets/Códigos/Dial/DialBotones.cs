using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialBotones : MonoBehaviour
{
    private int digito = 0;
    void Start()
    {
        this.GetComponentInChildren<Text>().text = digito.ToString();
        this.GetComponent<Button>().onClick.AddListener(CambiarValorBoton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CambiarValorBoton()
    {
        digito = digito >= 9 ? 0 : (digito+1); //Si digito es mayor o igual a 9, entonces su valor se resetea a 0; sino, solo se suma 1.
        this.GetComponentInChildren<Text>().text = digito.ToString(); //muestra el valor del dígito en el botón del canvas.
    }
}
