using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// this script is used to manage the whole game core
/// we manage the menu, game over, score and buttons
/// 
/// at the start of the scrit we set the values to false and get the best score
/// 
/// in the Update we manage the score text 
/// and check if the game over is true
/// 
/// the methods are used to manage UI components like menu or gameover
/// or the tutorial panel as well
/// 
/// in the CheckBestScore method we check if the actual score is greater then the best score
/// if its true then the best score will be equal to the score
/// else not
/// anyway show the two scores to the relative UI text 
/// </summary>


public class GameManager : MonoBehaviour {
    /// <summary>
    /// Instancia singleton de la clase GameManager
    /// </summary>
    public static GameManager s_instance;

    public int best;
    public bool isGameOver, isStarted;

    [SerializeField] Text scoreText, gameOverScoreTxt, bestScoreTxt;
    [SerializeField] Image medalImg;
    [SerializeField] GameObject mainMenuPanel, tutorialPanel, gameOverPanel;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject player;

    private GameState m_gameState;

    private void Awake() {
        if(FindObjectOfType<GameManager>() != null && 
            FindObjectOfType<GameManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        s_instance = this;
        m_gameState = GameState.None;
    }


    // Start is called before the first frame update
    void Start() {
        isGameOver = false;
        isStarted = false;
        best = PlayerPrefs.GetInt("BestScore");
    }

    // Update is called once per frame
    void Update() {
        UpdateScoreHUD();

        if (isGameOver) {
            GameOver();
        }

    }

    public void changeGameSate(GameState t_newState) {
        if(m_gameState == t_newState) {
            return;
        }
        m_gameState = t_newState;
        switch (m_gameState) {
            case GameState.None:
                break;
            case GameState.LoadMainMenu:
                break;
            case GameState.MainMenu:
                break;
            case GameState.Tutorial:
                openTutorial();
                break;
            case GameState.LoadLevel:
                startGame();
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                GameOver();
                break;
            default:
                throw new UnityException("Invalid Game State");
        }
    }

    public void changeGameStateInEditor(string newState) {
        changeGameSate((GameState)System.Enum.Parse(typeof(GameState), newState));
    }

    public void openTutorial() {
        mainMenuPanel.GetComponent<Animator>().SetTrigger("close");
        tutorialPanel.SetActive(true);
    }

    public void startGame() {
        //StartCoroutine(ActiveSpawner());
        scoreText.gameObject.SetActive(true);
        StartCoroutine(ActivePlayer());
        changeGameSate(GameState.Playing);
    }

    public GameState getGameState() {
        return m_gameState;
    }

    public void OpenTutorial() {
        mainMenuPanel.GetComponent<Animator>().SetTrigger("close");
        tutorialPanel.SetActive(true);
    }

    public void StartGame() {
        //StartCoroutine(ActiveSpawner());
        scoreText.gameObject.SetActive(true);

        //StartCoroutine(ActivePlayer());
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    IEnumerator ActivePlayer() {
        yield return new WaitForSeconds(2f);
        PlayerManager.s_instance.changePlayerState(PlayerState.Active);
        //player.GetComponent<PlayerController>().enabled = true;
        //player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    //IEnumerator ActiveSpawner() {
    //    yield return new WaitForSeconds(3f);
    //    spawner.SetActive(true);
    //    StartCoroutine(ActiveSpawner());
    //}

    void UpdateScoreHUD() {
        scoreText.text = PlayerManager.s_instance.getScore().ToString();
    }

    void GameOver() {
        scoreText.gameObject.SetActive(false);
        CheckBestScore();
        CheckMedal();
        gameOverPanel.SetActive(true);
    }

    void CheckMedal() {
        if (PlayerManager.s_instance.getScore() >= 100) {
            medalImg.gameObject.SetActive(true);
        }
    }

    void CheckBestScore() {
        best = PlayerPrefs.GetInt("BestScore");

        if (PlayerManager.s_instance.getScore() > best) {
            best = PlayerManager.s_instance.getScore();
            PlayerPrefs.SetInt("BestScore", best);


        }

        gameOverScoreTxt.text = PlayerManager.s_instance.getScore().ToString();
        bestScoreTxt.text = best.ToString();
    }
}

public enum GameState {
    None,
    LoadMainMenu,
    MainMenu,
    Tutorial,
    LoadLevel,
    Playing,
    GameOver
}
