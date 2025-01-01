using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEnterAdminCode : RiceMonoBehaviour
{
    [SerializeField] protected GameObject background;
    [SerializeField] protected TextMeshProUGUI title;
    [SerializeField] protected TextMeshProUGUI adminCodeDisplay;

    protected void FixedUpdate()
    {
        bool isAdminChecking = InputManager.Instance.adminCodeChecker.IsCheckingAdminCode();
        this.ActivateUI(isAdminChecking);

        if (isAdminChecking)
        {
            this.adminCodeDisplay.text = InputManager.Instance.adminCodeChecker.GetInputSequence();
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBackground();
        this.LoadTitle();
        this.LoadAdminCode();
    }

    protected virtual void LoadBackground()
    {
        if (this.background != null) return;
        this.background = transform.Find("Background").gameObject;
        Debug.Log(transform.name + " LoadBackground", gameObject);
    }

    protected virtual void LoadTitle()
    {
        if (this.title != null) return;
        this.title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " LoadTitle", gameObject);
    }

    protected virtual void LoadAdminCode()
    {
        if (this.adminCodeDisplay != null) return;
        this.adminCodeDisplay = transform.Find("AdminCode").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " LoadAdminCode", gameObject);
    }

    private void ActivateUI(bool active)
    {
        this.background.SetActive(active);
        this.title.gameObject.SetActive(active);
        this.adminCodeDisplay.gameObject.SetActive(active);
    }
}
