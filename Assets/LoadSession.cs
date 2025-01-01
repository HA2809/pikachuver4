using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSession : MonoBehaviour
{
    public Button continueButton;
    public string LoadSessionURL = "http://localhost/pikachudbver2/loadSession.php";

    void Start()
    {
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinueButtonClick);
        }
    }

    void OnContinueButtonClick()
    {
        // This method is now empty because we will call LoadUserSession directly from ContinueButtonHandler
    }

    public void LoadUserSession(string username, int modeID, int roundID)
    {
        StartCoroutine(LoadSessionData(username, modeID, roundID));
    }

    private IEnumerator LoadSessionData(string username, int modeID, int roundID)
    {
        WWWForm form = new WWWForm();
        form.AddField("UsernamePost", username);
        form.AddField("ModeIDPost", modeID);
        form.AddField("RoundIDPost", roundID);
        WWW www = new WWW(LoadSessionURL, form);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Response: " + www.text);

            string jsonResponse = www.text;
            SessionData sessionData = JsonUtility.FromJson<SessionData>(jsonResponse);

            Debug.Log("Loaded Session: " + sessionData);
            // Load other session data as needed
        }
    }

    [System.Serializable]
    public class SessionData
    {
        public int SessionID;
        public int RoundID;
        public int LevelID;
        public int PlayTime;
        public int HintUsed;
        public int ShuffleUsed;
        public bool State;
    }
}




