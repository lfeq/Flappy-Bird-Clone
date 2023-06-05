using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is used to manage the walls spawning
/// at the start of the scrit we call the coroutine to spawn the walls
/// every "time" the coroutine will create a random y value for our walls
/// and after that it will be spawn
/// 
/// the CheckIncrease method is used to check if is possible increase the time value 
/// if it is possible the IncreaseTime method will increase it
/// </summary>


public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] float xStart, minY, maxY;
    [SerializeField] int objectPoolLimit;

    Queue<GameObject> pipePool;
    bool canInstantiate = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
        pipePool = new Queue<GameObject>();
    }

    IEnumerator Spawning()
    {
        while (GameManager.s_instance.getGameState() != GameState.GameOver)
        {     
            yield return new WaitForSeconds(LevelManager.s_instance.getTime());
            if(GameManager.s_instance.getGameState() != GameState.Playing) {
                continue;
            }
            float rndY = Random.Range(minY, maxY);
            Vector2 startPos = new Vector2(xStart, rndY);
            if (canInstantiate) {
                pipePool.Enqueue(Instantiate(wall, startPos, Quaternion.identity));
                if (pipePool.Count > objectPoolLimit) {
                    canInstantiate = false;
                }
            }
            else {
                GameObject tempGO = pipePool.Dequeue();
                tempGO.transform.position = startPos;
                tempGO.SetActive(true);
                pipePool.Enqueue(tempGO);
            }
        }
    }
}
