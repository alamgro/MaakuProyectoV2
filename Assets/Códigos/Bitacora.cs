using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitacora : MonoBehaviour
{
    /*Bitácora de programadores. Aquí van registrados los avances individuales en el proyecto :D .
    -Alam, Álvaro: Modificación del inventario, se dejó un solo slot habilitado.
     Cuando presiona la tecla '1' Maaku suelta el objeto que lleve en el inventario.
    -Alam: Cambio de versión
    -Alvaro : Cambio de escenario que conserva los items y las interacciones del character con el.
    -Alvaro : Inventario con limite, y recoger item dropeado
    -Alam: Eliminar bug de duplicación de character cada que cambia de habitación (cuarto)
    -Daniel: animación salto y animación de agacharse  (Falta implementar)

    -Alam: Mejora del script Inventory: Se añade código para que suelte el item que tiene en el inventario cuandp presiona 1.
           Cambio en la forma de interactuar con objetos. Nuevo script "InteraccionObjeto" que sirve para cualquier objeto al que se añada como componente,
           haciendo flexible los cambios para cada uno. Este script detecta cuál objeto debe de ser tomado para ponerlo en el inventario.
           Se remueven los otros dos slots del inventario, solo quedó uno.
           Recreación del escenario "Habitacion2" dentro de la misma escena, se ponen todos los sprites.
           Reacomodo de carpetas de sprites para Habitación2.
           Se cambia el funcionamiento de la cámara, ahora sigue al personaje en habitaciones más grandes donde sea posible. Usando el paquete de componente Cinemachine

    -Alam: Se añade un Objeto AudioManager a la escena para manejar sonidos en el juego.
           Añadido clip de sonido para Cofre, puerta, e intro (pájaros sonando).
           Corrección de un bug en el cofre al recoger al oso.

    -Alam: Corrección de bug en script de la cama donde hacía que no pudiera tomar un item del cofre.
           Se añade nuevo script para objetos interactuables que únicamente aportan un diálogo. También hace que el jugador no se pueda mover hasta que haya leído todos los diálogos.
           Se remueve el indicador de presionar E para todos los objetos, excepto el primer dibujo de la pared (a forma de tutorial)
           Interacción nueva con el dibujo de la pared en la habitación 1.
           Creación de script GameManager para verificar el progreso de la historia con la variable "secuenciaActual". Con esto ya se hizo la secuencia:
           1- Interactuar con dibujo, abrir closet, abrir cofre (No es la secuencia real en la historia, pero se usó para testing)


    -Daniel: Invita la pizza. Y las chelas, aunque no le dé.
           Corrección de movimientos generales (agacharse y brincar), se arregla bug de brincos múltiples.
    -Alam: Corrección de secuencia de interacciones para comprobar con cuáles objetos se puede interactuar primero.
           Nuevo código para hacer zoom al objeto que se tiene en el inventario con la tecla "2".
    -Alvaro: Código de contador de tiempo para que el diálogo se borre después de 5 segundos.
    -Grupal: Se trabaja en el inicio de los primeros pasos del juego.
           
    -Alam: Modificación de script para poder añadir diálogos a acada objeto y que se tenga que presionar E para pasar al siguiente diálogo.
           Easter Egg "Voces en la cabeza", si Maaku se queda parada por más de 20 segundos empieza a escuchar voces. 

    -Alam: Código "DialBotones" para controlar los botones que se usarán para ingresar el código del candado.
    -Grupal: Script para objetos estando agachado, Makuu se queda volteada hasta que deje de interactuar, correcion de coliders, correcion de interacciones, correcion de puertas, correcion bug de movimiento.
     */
}
