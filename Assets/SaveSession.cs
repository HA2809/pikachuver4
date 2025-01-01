using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSession : MonoBehaviour
{
    public Button exitButton;
    public string username;
    public string SaveSessionURL = "http://localhost/pikachudbver2/saveSession.php";

    public int roundID;
    public int levelID;
    public int playTime;
    public int hintUsed;
    public int shuffleUsed;
    public bool state;

    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClick);
        }
    }

    public void OnExitButtonClick()
    {
        UpdatePlayerProgress();

        StartCoroutine(SaveSessionData(username, roundID, levelID, playTime, hintUsed, shuffleUsed, state));
    }

    private void UpdatePlayerProgress()
    {
        roundID = GameManager.Instance.CurrentRoundID;
        levelID = GameManager.Instance.CurrentLevel;
        playTime = GameManager.Instance.CurrentPlayTime;
        hintUsed = GameManager.Instance.RemainHint;
        shuffleUsed = GameManager.Instance.RemainShuffle;
        state = GameManager.Instance.CurrentState;
    }

    private IEnumerator SaveSessionData(string Username, int RoundID, int LevelID, int PlayTime, int HintUsed, int ShuffleUsed, bool State)
    {
        WWWForm form = new WWWForm();
        form.AddField("UsernamePost", Username);
        form.AddField("RoundID", RoundID);
        form.AddField("LevelID", LevelID);
        form.AddField("PlayTime", PlayTime);
        form.AddField("HintUsed", HintUsed);
        form.AddField("ShuffleUsed", ShuffleUsed);
        form.AddField("State", State ? 1 : 0);
        WWW www = new WWW(SaveSessionURL, form);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Response: " + www.text);
        }
    }
}




