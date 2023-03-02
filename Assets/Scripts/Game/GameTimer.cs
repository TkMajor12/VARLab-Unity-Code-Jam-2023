using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField, Range(0, 60)] private int minutes;
    [SerializeField, Range(0, 60)] private int seconds;
    [SerializeField] private TMP_Text clock;

    // Start is called before the first frame update
    void Start()
    {
        DisplayTime();
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (seconds == 0)
            {
                if (minutes == 0)
                {
                    clock.text = "Props win!";
                    yield return new WaitForSeconds(5f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    yield break;
                }

                seconds = 60;
                minutes--;
            }

            seconds--;
            DisplayTime();
        }
    }

    private void DisplayTime()
    {
        string seconds = this.seconds >= 10 ? this.seconds.ToString() : $"0{this.seconds}";
        string minutes = this.minutes >= 10 ? this.minutes.ToString() : $"0{this.minutes}";

        clock.text = $"{minutes}:{seconds}";
    }
}
