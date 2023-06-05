using UnityEngine;

/// <summary>
/// this script is used to control our player
/// and manage his collisions
/// at the start of the scrit we get player's rigidbody2D component
/// in the Jump method we get the input and push up the player
/// adding a force to his rb
/// 
/// we also check the collisions with the walls and triggers with the scores
/// if the player hit the wall its gameover
/// else if the player trigger the score we will increase the value score in gm(Game Manager)
/// </summary>


public class PlayerController: MonoBehaviour {
    Rigidbody2D rb;

    [SerializeField] private float force;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.s_instance.getGameState() != GameState.Playing) {
            return;
        }
        Jump();
    }

    private void Jump() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {

            rb.velocity = new Vector2(rb.velocity.x, 1 * force);
        }
    }
}
