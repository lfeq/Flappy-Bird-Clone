using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is used to control the background scroll
///
/// in the Update we move the bg to left
/// 
/// if bg's x position is lower then -10.5f
/// then reset the position to the start position
///
/// </summary>


public class BgScroller : MonoBehaviour
{

    private Vector3 startPos;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);

        if (transform.position.x < -10.5f)
        {
            transform.position = startPos;
        }
    }
}
