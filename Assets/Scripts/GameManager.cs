using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float tiempoPausa = 1.5f;
    [SerializeField] private TMP_Text textoPuntaje;
    [SerializeField] private GameObject textoInicio;
    private int puntaje = 0;
    private EstadoJuego estadoJuego = EstadoJuego.Esperando;


    void Start()
    {
        ActualizarTexto();
    }


    IEnumerator Reiniciar()
    {
        yield return new WaitForSecondsRealtime(tiempoPausa);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void TerminarJuego()
    {
        estadoJuego = EstadoJuego.GameOver;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
        StartCoroutine(Reiniciar());

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
}


public enum EstadoJuego
{
    Esperando,
    Jugando,
    GameOver
}
