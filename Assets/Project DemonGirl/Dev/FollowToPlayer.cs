using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    // Objeto al que se va a seguir. Se asigna desde el Inspector.
    public Transform objetivo;

    // Velocidad a la que el objeto seguirá al objetivo.
    [Header("Configuración de Movimiento")]
    [Tooltip("Velocidad de movimiento del objeto de seguimiento.")]
    public float velocidadSeguimiento = 5.0f;

    // Distancia mínima para dejar de seguir (o comenzar si ya está cerca).
    [Header("Configuración de Distancia")]
    [Tooltip("Distancia mínima del objetivo. Si está más cerca, se detiene o se ralentiza.")]
    public float distanciaMinima = 1.0f;

    // Distancia máxima para empezar a seguir.
    [Tooltip("Distancia máxima para comenzar a seguir. Si está más lejos, el objeto permanece quieto.")]
    public float distanciaMaxima = 10.0f;

    private void Update()
    {
        // 1. Verificar si tenemos un objetivo asignado
        if (objetivo == null)
        {
            Debug.LogWarning("No hay un objetivo asignado al script 'SeguirObjetivo' en el GameObject: " + gameObject.name);
            return;
        }

        // 2. Calcular la distancia actual al objetivo
        float distanciaActual = Vector3.Distance(transform.position, objetivo.position);

        // 3. Lógica de seguimiento
        if (distanciaActual > distanciaMinima && distanciaActual <= distanciaMaxima)
        {
            // El objeto está dentro del rango de seguimiento (entre Min y Max).

            // Calcula la dirección hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Mueve el objeto hacia el objetivo usando la velocidad y el tiempo delta.
            transform.position += direccion * velocidadSeguimiento * Time.deltaTime;

            // Opcional: Rotar para mirar al objetivo
            // transform.LookAt(objetivo);
        }
        else if (distanciaActual > distanciaMaxima)
        {
            // El objeto está muy lejos, no hace nada (o puedes añadir otra lógica).
            // Debug.Log("Objetivo fuera del rango máximo de seguimiento.");
        }
        else if (distanciaActual <= distanciaMinima)
        {
            // El objeto está muy cerca, se detiene o mantiene una distancia.
            // Debug.Log("Objetivo dentro del rango mínimo de separación.");
        }
    }
}
