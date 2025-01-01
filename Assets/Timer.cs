using System;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : RiceMonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    float fplayTime;
    public event Action OnTimeUp;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPaused) return; 

        fplayTime += Time.deltaTime;
        int playTime = Mathf.FloorToInt(fplayTime * 1000);

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
            OnTimeUp?.Invoke();
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


    //public void Pause()
    //{
    //    pauseMenu.SetActive(true);
    //    Time.timeScale = 0;
    //}

    //public void Resume()
    //{
    //    pauseMenu.SetActive(false);
    //    Time.timeScale = 1;
    //}

