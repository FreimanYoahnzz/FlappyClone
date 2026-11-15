using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float tiempoPausa = 1.5f;


    IEnumerator Reiniciar()
    {
        yield return new WaitForSecondsRealtime(tiempoPausa);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void TerminarJuego()
    {
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
        StartCoroutine(Reiniciar());
    }
}
