using UnityEngine;
using UnityEngine.InputSystem;

public class Pajaro : MonoBehaviour
{
    [SerializeField] private float fuerzaAleteo = 5f;
    private Rigidbody2D rb;
    [SerializeField] private float inclinacionMin = -60f;
    [SerializeField] private float inclinacionMax = 60f;
    [SerializeField] private float multiplicadorInclinacion = 6f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Pointer.current.press.wasPressedThisFrame || (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame))
        {
            rb.linearVelocity = new Vector2(0f, fuerzaAleteo);
        }

        float angulo = multiplicadorInclinacion * rb.linearVelocity.y;
        float inclinacion = Mathf.Clamp(angulo, inclinacionMin, inclinacionMax);
        transform.rotation = Quaternion.Euler(0f, 0f, inclinacion);

    }
}
