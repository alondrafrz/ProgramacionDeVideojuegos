using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    void Update()
    {
        // movimiento horizontal
        float h = Input.GetAxis("Horizontal");

        if (h != 0)
        {
            Debug.Log("[Input MOVIMIENTO] Eje horizontal detectado: " + h);
        }

        // Detección de salto 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            Debug.Log("Salto detectado");
        }
    }
}