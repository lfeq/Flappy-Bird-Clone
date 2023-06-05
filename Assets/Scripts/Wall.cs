using UnityEngine;

/// <summary>
/// this script is used to move and control the wall forward the player
/// the MoveWall method is used to move the walls
/// the CheckPos method is used to check the actual position of the wall and destroy it
/// </summary>
public class Wall : MonoBehaviour
{

    [SerializeField] float speed;

    // Update is called once per frame
    void Update() {
        if (GameManager.s_instance.getGameState() != GameState.Playing) {
            return;
        }
        MoveWall();
        CheckPos();
    }

    void MoveWall()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
    }

    void CheckPos()
    {
        if (transform.position.x <= -6f)
        {
            gameObject.SetActive(false);
        }
    }
}
