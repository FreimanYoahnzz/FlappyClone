using UnityEngine;

public class DesplazamientoInfinito : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;           // qué tan rápido se mueve hacia la izquierda
    [SerializeField] private float anchoRepeticion = 8.08f;  // cuánto mide UNA repetición de la imagen, en unidades
    private Vector3 posicionInicial;


    void Start()
    {
        posicionInicial = transform.position;   // recordar dónde empezó
    }


    void Update()
    {
        // 1. Moverse hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;

        // 2. Si ya avanzó una repetición completa, volver al inicio
        if (transform.position.x <= posicionInicial.x - anchoRepeticion)
        {
            transform.position = posicionInicial;
        }
    }
}
