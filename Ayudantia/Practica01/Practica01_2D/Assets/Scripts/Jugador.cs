using UnityEngine;

public class Jugador : MonoBehaviour
{
    public bool enSuelo = false;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            Debug.Log("Ha comenzado la colisión con el suelo: " + col.gameObject.name);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
            Debug.Log("El jugador ha salido del suelo: " + col.gameObject.name);
        }
    }
} 