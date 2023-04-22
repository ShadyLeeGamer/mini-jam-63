using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameGUI : MonoBehaviour
{
    public bool gameOver;
    public bool startTimer;

    public float defaultTimer, timer;
    public float startDuration, midDuration;
    public float timeLeft;

    public GameObject gameGUI;
    public GameObject winGUI;

    public TextMeshPro durationTXT;
    public TextMeshProUGUI timeLeftTXT;

    void Start()
    {
        Player.StopTimeAction += StartTiming;
        defaultTimer = timer;
    }

    void Update()
    {
        if(timeLeft > 0 && timeLeftTXT)
        timeLeftTXT.text = Convert.ToInt32(timeLeft -= Time.deltaTime * TimeScale.time).ToString();

        if (timer.Equals(defaultTimer))
            durationTXT.text = "";

        if (startTimer)
        {
            timer -= midDuration * Time.deltaTime;
            durationTXT.text = Convert.ToInt32(timer).ToString();
        }
        else
            timer = defaultTimer;
    }

    public void StartTiming()
    {
        StartCoroutine(FixedTiming());
    }

    IEnumerator FixedTiming()
    {
        yield return new WaitForSeconds(startDuration);
        startTimer = true;
        yield return new WaitForSeconds(defaultTimer);
        startTimer = false;
    }

    public void Win()
    {
        gameGUI.SetActive(false);
        winGUI.SetActive(true);

        gameOver = true;
    }
}
