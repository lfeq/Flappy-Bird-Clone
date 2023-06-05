using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager s_instance;
    
    private float time = 2.2f;


    private void Awake() {
        if(FindObjectOfType<LevelManager>() != null &&
            FindObjectOfType<LevelManager>().gameObject != gameObject) {
            Destroy(gameObject);
        }
        else {
            s_instance = this;
        }
    }

    public float getTime() {
        return time;
    }

    public void checkIncrease(int t_score) {
        if(t_score > 100) {
            return;
        }
        if(t_score % 20 == 0) {
            IncreaseTime();
        }
    }

    void IncreaseTime() {
        if (time >= 1.2f) {
            time -= 0.2f;
        }
    }
}
