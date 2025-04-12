using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TimeText;
    public TMP_Text TimeWin;
    public TMP_Text TimeLose;
    private string LuuText;
    private float startTime;
    private bool isCounting;
    void Start()
    {
        startTime = Time.time;
        isCounting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCounting) return;
        Player_Controller dieukien = FindObjectOfType<Player_Controller>();
        UI_Controller a = FindObjectOfType<UI_Controller>();
        float dem;
        dem = Time.time - startTime;

        int m = (int)dem / 60;
        int s = (int)dem % 60;
        TimeText.text = string.Format("{00:00}:{1:00}", m,s);
        LuuText = TimeText.text;
        if (dieukien.isLose == true || dieukien.isWin == true )
        {
            stopTime();
            TimeWin.text = LuuText;
            TimeLose.text = LuuText;
        }

        if(a.a == true)
        {
            dem = 0;
        }
        

    }
    public void stopTime()
    {
        isCounting = false; 
    }
}
