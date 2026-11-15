using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void TerminarJuego()
    {
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
    }
}
