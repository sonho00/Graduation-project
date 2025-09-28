using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BrickManager brickManager;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject retryMenu;

    [SerializeField] private TextMeshProUGUI goldText;
    private int _gold = 0;
    public int gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            goldText.text = "Gold: " + _gold;
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;
    public int score;
    public GameState gameState;

    private void Start()
    {
        NextRound();
    }

    public void Fire(Vector2 start, Vector2 end)
    {
        if (gameState == GameState.Ready)
        {
            if (weaponManager.Fire(start, end))
            {
                gameState = GameState.Play;
            }
            else
            {
                gameState = GameState.Ready;
            }
        }
    }

    public void NextRound()
    {
        brickManager.CreateBrick(++score);
        if (brickManager.IsGameOver())
        {
            gameState = GameState.GameOver;
            retryMenu.SetActive(true);
            scoreText.text = "Score: " + score;
        }
        else
        {
            ++gold;
            gameState = GameState.Ready;
            weaponManager.ReselectWeapon();
        }
    }

    public void Pause()
    {
        gameState = GameState.Pause;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        gameState = GameState.Ready;
        pauseMenu.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
