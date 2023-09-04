using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public string LevelName;
    public bool LevelCompleted;
    public bool CanPlayLevel;

    private Image image;
    private TextMeshProUGUI tmp;
    private void Awake()
    {   
        this.image = this.gameObject.GetComponent<Image>();

        if (!this.CanPlayLevel)
        {
            this.image.color = Color.gray;
        }
        if (this.LevelCompleted)
        {
            this.image.color = Color.green;
        }

        this.tmp = this.GetComponentInChildren<TextMeshProUGUI>();
        this.tmp.text = this.LevelName;
    }

    private void Start()
    {
        MasterObject.instance.levelStateManager.Level.Add(this);
    }

    public void OnClick()
    {
        if (!this.CanPlayLevel)
            return;

        MasterObject.instance.sceneLoader.LoadLevel(this.LevelName);
    }
}
