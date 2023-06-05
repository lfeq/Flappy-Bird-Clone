using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager s_instance;

    [SerializeField] AudioSource dieAudio, pointAudio, flyAudio;

    int score = 0;
    PlayerState playerSate;

    private void Awake() {
        if (FindObjectOfType<PlayerManager>() != null &&
            FindObjectOfType<PlayerManager>().gameObject != gameObject) {
            Destroy(gameObject);
        }
        else {
            s_instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        playerSate = PlayerState.None;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall") && (playerSate != PlayerState.Dead)) {
            changePlayerState(PlayerState.Dead);
        }
    }

    private void playerDead() {
        dieAudio.Play();
        GameManager.s_instance.changeGameSate(GameState.GameOver);
        //this.enabled = false;
    }

    public int getScore() {
        return score;
    }

    public void changePlayerState(PlayerState newState) {
        if (playerSate == newState) {
            return;
        }
        playerSate = newState;
        switch (playerSate) {
            case PlayerState.None:
                break;
            case PlayerState.Jump:
                break;
            case PlayerState.Active:
                activatePlayer();
                break;
            case PlayerState.Dead:
                playerDead();
                break;
        }
    }

    public void activatePlayer() {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Score") && (playerSate != PlayerState.Dead)) {
            pointAudio.Play();
            score++;
            LevelManager.s_instance.checkIncrease(score);
        }
    }    
}

public enum PlayerState {
    None,
    Jump,
    Dead,
    Active
}