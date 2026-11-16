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
    private int puntaje = 0;
    private EstadoJuego estadoJuego = EstadoJuego.Esperando;


    void Start()
    {
        ActualizarTexto();
    }


    IEnumerator MostrarGameOver()
    {
        yield return new WaitForSecondsRealtime(tiempoPausa);
        textoPuntajeFinal.text = "Puntaje: " + puntaje;
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
}


public enum EstadoJuego
{
    Esperando,
    Jugando,
    GameOver
}
