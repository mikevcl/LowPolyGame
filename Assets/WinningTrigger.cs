using UnityEngine;

public class WinningTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private bool wonGame = false;

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
        wonGame = true;
    }
    public bool getWin()
    {
        return wonGame;
    }
}
