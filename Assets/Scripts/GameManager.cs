using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float tiempoPausa = 0.15f;
    [SerializeField] private TMP_Text textoPuntaje;
    [SerializeField] private GameObject textoInicio;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text textoPuntajeFinal;
    [SerializeField] private TMP_Text textoMejorPuntaje;
    [SerializeField] private GameObject textoNuevoRecord;
    [SerializeField] private GameObject textoRecordEnPartida;
    [SerializeField] private float duracionAvisoRecord = 1.5f;
    private int puntaje = 0;
    private EstadoJuego estadoJuego = EstadoJuego.Esperando;
    private const string ClaveMejorPuntaje = "MejorPuntaje";
    private int mejorPuntajeGuardado;
    private bool recordYaAvisado = false;



    void Start()
    {
        ActualizarTexto();
        mejorPuntajeGuardado = PlayerPrefs.GetInt(ClaveMejorPuntaje, 0);
    }


    IEnumerator MostrarGameOver()
    {
        yield return new WaitForSecondsRealtime(tiempoPausa);
        textoPuntajeFinal.text = "Puntaje: " + puntaje;
        ActualizarMejorPuntaje();
        panel.SetActive(true);
    }


    public void TerminarJuego()
    {
        estadoJuego = EstadoJuego.GameOver;
        Time.timeScale = 0f;
        StartCoroutine(MostrarGameOver());

    }


    private void ActualizarTexto()
    {
        textoPuntaje.text = "Puntaje: " + puntaje.ToString();
    }


    public void SumarPunto()
    {
        puntaje += 1;
        ActualizarTexto();

        if (!recordYaAvisado && mejorPuntajeGuardado > 0 && puntaje > mejorPuntajeGuardado)
        {
            recordYaAvisado = true;
            StartCoroutine(MostrarAvisoRecord());
        }
    }

    public bool EstaJugando()
    {

        return estadoJuego == EstadoJuego.Jugando;
    }

    public void EmpezarJuego()
    {
        estadoJuego = EstadoJuego.Jugando;
        textoInicio.SetActive(false);
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void ActualizarMejorPuntaje()
    {
        int mejorPuntaje = PlayerPrefs.GetInt(ClaveMejorPuntaje, 0);
        if (puntaje > mejorPuntaje)
        {
            mejorPuntaje = puntaje;
            PlayerPrefs.SetInt(ClaveMejorPuntaje, mejorPuntaje);
            PlayerPrefs.Save();
            textoNuevoRecord.SetActive(true);
        }

        textoMejorPuntaje.text = "Mejor Puntaje: " + mejorPuntaje;
    }


    IEnumerator MostrarAvisoRecord()
    {
        textoRecordEnPartida.SetActive(true);
        yield return new WaitForSeconds(duracionAvisoRecord);
        textoRecordEnPartida.SetActive(false);
    }
}


public enum EstadoJuego
{
    Esperando,
    Jugando,
    GameOver
}
