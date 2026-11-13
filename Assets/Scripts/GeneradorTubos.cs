using UnityEngine;

public class GeneradorTubos : MonoBehaviour
{
    [SerializeField] private GameObject prefabTubos;
    [SerializeField] private float intervaloAparicion = 3f;
    [SerializeField] private float alturaMaxima = 3f;
    [SerializeField] private float alturaMinima = -2f;
    private float temporizador = 2f;

    void Start()
    {
        temporizador = intervaloAparicion;
    }
    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= intervaloAparicion)
        {

            temporizador = 0f;
            float posicionY = Random.Range(alturaMinima, alturaMaxima);
            float posicionX = transform.position.x;
            float posicionZ = 0f;
            Vector3 puntoAparicion = new Vector3(posicionX, posicionY, posicionZ);
            Instantiate(prefabTubos, puntoAparicion, Quaternion.identity);
        }

    }
}
