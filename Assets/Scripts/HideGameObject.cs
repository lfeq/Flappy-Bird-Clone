using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script is used to hide objects
/// we can use it from animators and other scripts
/// 
/// we will use it in some animations
/// </summary>
 

public class HideGameObject : MonoBehaviour
{

    void HideObj()
    {
        this.gameObject.SetActive(false);
    }
}
