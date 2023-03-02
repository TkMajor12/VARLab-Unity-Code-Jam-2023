using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour
{
    private int collisions = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hider"))
        {
            collisions += 1;
        }

        if(collisions == 3)
        {
            Debug.Log("Win");
        }
    }
}
