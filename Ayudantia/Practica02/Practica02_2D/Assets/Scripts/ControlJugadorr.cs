using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidadActual = 0f;
    public float velocidadMax = 5f;
    public float aceleracion = 10f;
    public float velocidadVertical = 0f;
    public float gravedad = -20f;
    public float tiempoMaxSalto = 0.2f;
    private float tiempoSaltoActual = 0f;
    private float tiempoAnterior;

    private Jugador jugador;

    void Awake()
    {
        // Comunicación entre componentes mediante GetComponent
        jugador = GetComponent<Jugador>();
        tiempoAnterior = Time.time;
    }

    void Update()
    {
        // Cálculo manual de deltaTime
        float delta = Time.time - tiempoAnterior;
        tiempoAnterior = Time.time;

        // Movimiento lateral con aceleración
        float h = Input.GetAxis("Horizontal");
        velocidadActual += h * aceleracion * delta;
        velocidadActual = Mathf.Clamp(velocidadActual, -velocidadMax, velocidadMax);
        transform.position += new Vector3(velocidadActual * delta, 0, 0);

        // Implementación del salto
        if (Input.GetAxis("Jump") > 0 && jugador.enSuelo)
        {
            velocidadVertical = 10f;
            jugador.enSuelo = false;
            tiempoSaltoActual = 0f;
        }

        if (!jugador.enSuelo && Input.GetAxis("Jump") > 0)
        {
            if (tiempoSaltoActual < tiempoMaxSalto)
            {
                velocidadVertical += 20f * delta;
                tiempoSaltoActual += delta;
            }
        }

        if (Input.GetAxis("Jump") == 0)
        {
            tiempoSaltoActual = tiempoMaxSalto;
        }

        // Aplicar gravedad o restablecer velocidad en el suelo
        if (jugador.enSuelo)
        {
            velocidadVertical = 0;
        }
        else
        {
            velocidadVertical += gravedad * delta;
        }

        // Mover al personaje verticalmente
        transform.position += new Vector3(0, velocidadVertical * delta, 0);

        Debug.Log("En suelo: " + jugador.enSuelo + " | Vel Vertical: " + velocidadVertical);
    }
}