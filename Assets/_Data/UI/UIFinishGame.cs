using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinishGame : RiceMonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject winFx;

    protected override void Start()
    {
        base.Start();
        GameManager.Instance.OnFinishGame += GameManager_OnFinishGame;
    }

    private void GameManager_OnFinishGame()
    {
        ShowUI();
        SoundManager.Instance.PlaySound(SoundManager.Sound.finish);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContainer();
    }

    private void LoadContainer()
    {
        if (this.container != null) return;
        this.container = transform.Find("Container").gameObject;
        Debug.Log(transform.name + ": LoadContainer", gameObject);
    }

    private void ShowUI()
    {
        if (container != null)
        {
            container.SetActive(true);
        }
        if (winFx != null)
        {
            winFx.SetActive(true);
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnFinishGame -= GameManager_OnFinishGame;
        }
    }
}
