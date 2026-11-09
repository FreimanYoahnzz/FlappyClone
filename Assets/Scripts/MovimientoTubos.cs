using UnityEngine;

public class MovimientoTubos : MonoBehaviour
{
    [SerializeField] private float velocidad = 1f;
    [SerializeField] private float limIzquierdo = -12f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // rb.linearVelocity = new Vector2(-velocidad, 0f);
        rb.linearVelocity = Vector2.left * velocidad;
    }

    void Update()
    {
        if (transform.position.x <= limIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}
