using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float respawnTime = 3.0f;
    public int lives = 3;

    public void PlayerDied()
    {
        this.lives--;
        if (this.lives > 0)
        {
            GameOver();
        }
        Invoke(nameof(RespawnPlayer), respawnTime);
    }

    private void RespawnPlayer()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
