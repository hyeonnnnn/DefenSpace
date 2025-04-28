using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false); 
    }

    public void GameOver()
    {
        Time.timeScale = 0f; 
        gameOverPanel.SetActive(true); 
    }
}
