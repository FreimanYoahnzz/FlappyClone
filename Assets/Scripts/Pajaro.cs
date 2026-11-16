using UnityEngine;
using UnityEngine.InputSystem;

public class Pajaro : MonoBehaviour
{
    [SerializeField] private float fuerzaAleteo = 6f;
    [SerializeField] private float inclinacionMin = -60f;
    [SerializeField] private float inclinacionMax = 60f;
    [SerializeField] private float multiplicadorInclinacion = 6f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject prefabTextoFlotante;
    [SerializeField] private Vector3 desplazamiento = new Vector3(0f, 0.8f, 0f);
    private Rigidbody2D rb;
    private bool estaVivo = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        rb.simulated = false;
    }


    void Update()
    {
        if (!estaVivo)
        {
            return;   // termina Update aquí, no se ejecuta lo de abajo
        }

        if (Pointer.current.press.wasPressedThisFrame || (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame))
        {
            if (!gameManager.EstaJugando())
            {
                gameManager.EmpezarJuego();
                rb.simulated = true;
            }
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
            gameManager.SumarPunto();
            Instantiate(prefabTextoFlotante, (transform.position + desplazamiento), Quaternion.identity);
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
