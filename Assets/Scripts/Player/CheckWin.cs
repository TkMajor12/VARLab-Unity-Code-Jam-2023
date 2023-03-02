using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private TMP_Text clock;
    private int collisions = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hider"))
        {
            collisions += 1;
        }

        if(collisions == 3)
        {
            clock.text = "Seekers win!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
