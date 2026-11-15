using UnityEngine;
using UnityEngine.InputSystem;

public class Pajaro : MonoBehaviour
{
    [SerializeField] private float fuerzaAleteo = 6f;
    [SerializeField] private float inclinacionMin = -60f;
    [SerializeField] private float inclinacionMax = 60f;
    [SerializeField] private float multiplicadorInclinacion = 6f;
    [SerializeField] private GameManager gameManager;
    private Rigidbody2D rb;
    private int puntaje = 0;
    private bool estaVivo = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!estaVivo)
        {
            return;   // termina Update aquí, no se ejecuta lo de abajo
        }

        if (Pointer.current.press.wasPressedThisFrame || (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame))
        {
            rb.linearVelocity = new Vector2(0f, fuerzaAleteo);
        }

        float angulo = multiplicadorInclinacion * rb.linearVelocity.y;
        float inclinacion = Mathf.Clamp(angulo, inclinacionMin, inclinacionMax);
        transform.rotation = Quaternion.Euler(0f, 0f, inclinacion);
    }


    void OnTriggerEnter2D(Collider2D objeto)
    {

        if (objeto.CompareTag("ZonaPuntaje"))
        {
            puntaje += 1;
            Debug.Log("PUNTUACIÓN " + puntaje);
        }
    }


    void OnCollisionEnter2D(Collision2D choque)
    {
        if (!estaVivo)
        {
            return;
        }

        estaVivo = false;
        gameManager.TerminarJuego();
    }
}
