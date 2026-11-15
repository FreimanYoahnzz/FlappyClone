using TMPro;
using UnityEngine;

public class TextoFlotante : MonoBehaviour
{
    [SerializeField] private float velocidadSubida = 1.5f;
    [SerializeField] private float duracion = 0.8f;
    private TMP_Text texto;
    private float temporizador;


    private void Awake()
    {
        texto = GetComponent<TMP_Text>();
    }


    void Update()
    {
        transform.position += (Vector3.up * velocidadSubida * Time.deltaTime);
        temporizador += Time.deltaTime;
        texto.alpha = 1f - (temporizador / duracion);

        if (temporizador >= duracion)
        {
            Destroy(gameObject);
        }
    }
}
