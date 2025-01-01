using UnityEngine;

public class InputManager : RiceSingleton<InputManager>
{
    public bool isDebug = false;
    public KonamiCodeChecker konamiCodeChecker { get; private set; }
    public AdminCodeChecker adminCodeChecker { get; private set; }

    protected override void Start()
    {
        base.Start();
        konamiCodeChecker = new KonamiCodeChecker();
        adminCodeChecker = new AdminCodeChecker();
    }

    protected void Update()
    {
        this.ToogleDebugMode();
        this.CheckingKonamiInput();
        this.ToogleAdminMode();
        this.CheckingAdminInput();
        this.ClearChooseBlock();
        this.DeleteChooseBlock();
    }

    protected virtual void ToogleDebugMode()
    {
        if (Input.GetKeyUp(KeyCode.F3))
        {
            if (isDebug)
            {
                ActivateDebugMode(false);
                return;
            }
            else if (konamiCodeChecker.IsCheckingKonamiCode())
            {
                konamiCodeChecker.SetCheckingKonamiCode(false);
                konamiCodeChecker.Reset();
            }
            else
            {
                konamiCodeChecker.SetCheckingKonamiCode(true);
            }

        }
    }

    private void CheckingKonamiInput()
    {
        if (!konamiCodeChecker.IsCheckingKonamiCode()) return;

        konamiCodeChecker.CheckInput();

        if (!konamiCodeChecker.IsCodeEntered) return;

        ActivateDebugMode(true);
        konamiCodeChecker.SetCheckingKonamiCode(false);
        konamiCodeChecker.Reset();
    }

    private void ActivateDebugMode(bool active)
    {
        isDebug = active;
    }

    protected virtual void ToogleAdminMode()
    {
        if (Input.GetKeyUp(KeyCode.F10))
        {
            if (adminCodeChecker.IsCheckingAdminCode())
            {
                adminCodeChecker.SetCheckingAdminCode(false);
                adminCodeChecker.Reset();
            }
            else
            {
                adminCodeChecker.SetCheckingAdminCode(true);
            }
        }
    }

    private void CheckingAdminInput()
    {
        if (!adminCodeChecker.IsCheckingAdminCode()) return;

        adminCodeChecker.CheckInput();

        if (!adminCodeChecker.IsCodeEntered) return;

        ActivateAdminMode(true);
        adminCodeChecker.SetCheckingAdminCode(false);
        adminCodeChecker.Reset();
    }

    private void ActivateAdminMode(bool active)
    {
        if (active)
        {
            Debug.Log("Admin Mode Activated!");
            // Add admin-specific logic here
        }
    }

    protected virtual void DeleteChooseBlock()
    {
        if (Input.GetKeyUp(KeyCode.Delete)) GridManagerCtrl.Instance.blockDebug.DeleteFirstBlock();
    }

    protected virtual void ClearChooseBlock()
    {
        if (Input.GetMouseButtonUp(1))
        {
            GridManagerCtrl.Instance.blockHandler.Unchoose();
            BlockDebug.Instance.ClearDebug();
        }
    }

    public void ActiveDebugMode(bool active)
    {
        this.isDebug = active;
    }
}
