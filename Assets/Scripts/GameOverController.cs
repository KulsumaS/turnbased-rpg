using UnityEngine;

public class GameOverController : MonoBehaviour
{
    
    public GameOverScreen gameOverScreen;
    public FighterStats stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        Gameover();
    }
    
    public void Gameover()
    {
        if (stats.health == 0)
        {
            gameOverScreen.Setup();
        }
    }
}
