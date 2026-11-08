using UnityEngine;
using UnityEngine.InputSystem;

public class Pajaro : MonoBehaviour
{
    [SerializeField] private float fuerzaAleteo = 5f;
    private Rigidbody2D rb;

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
    }
}
