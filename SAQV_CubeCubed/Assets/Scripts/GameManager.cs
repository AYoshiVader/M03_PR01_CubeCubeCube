using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public delegate void TurningEvent(int turnTarget);
    public event TurningEvent TurningTime;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            UnityEngine.Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Turner(int turnDirection)
    {
        TurningTime(turnDirection);
    }
}