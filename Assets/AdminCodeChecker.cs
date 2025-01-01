using UnityEngine;

public class AdminCodeChecker
{
    private readonly string adminCode = "ricerising";
    private string inputSequence = "";

    private bool isCheckingAdminCode = false;

    public bool IsCodeEntered { get; private set; } = false;

    public void CheckInput()
    {
        if (IsCodeEntered) return;

        string keyPressed = GetPressedKey();
        if (!string.IsNullOrEmpty(keyPressed))
        {
            inputSequence += keyPressed;

            if (inputSequence == adminCode)
            {
                IsCodeEntered = true;
                Debug.Log("Admin Code Entered!");
            }
            else if (!adminCode.StartsWith(inputSequence))
            {
                Reset();
            }
        }
    }

    private string GetPressedKey()
    {
        foreach (char c in Input.inputString)
        {
            return c.ToString();
        }
        return null;
    }

    public void Reset()
    {
        inputSequence = "";
        IsCodeEntered = false;
    }

    public void SetCheckingAdminCode(bool active)
    {
        isCheckingAdminCode = active;
    }

    public bool IsCheckingAdminCode() => isCheckingAdminCode;

    public string GetInputSequence() => inputSequence;

}
