using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelMenu : MonoBehaviour
{
    public string text;
    private Text NextLevelText;
    private int _level;

    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            NextLevelText.text = text + (value+1).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        NextLevelText = transform.Find("NextLevel").GetComponent<Text>();
        text = NextLevelText.text;
    }

}
