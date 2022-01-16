using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveTimer : MonoBehaviour
{
    public Text livesTimer;
    public Text lives;
    private void Update()
    {
        System.TimeSpan diff = Timer.GetTimeSpan();

        System.TimeSpan Hour2 = new System.TimeSpan(2, 0, 0);
        Hour2 -= diff;

        if (Hour2.Hours >= 0 && Hour2.Minutes >= 0 && Hour2.Seconds >= 0)
        {
            int hour = Hour2.Hours;
            string min, sec;

            if (Hour2.Minutes < 10)
                min = "0" + (Hour2.Minutes).ToString();
            else
                min = (Hour2.Minutes).ToString();


            if (Hour2.Seconds < 10)
                sec = "0" + (Hour2.Seconds).ToString();
            else
                sec = (Hour2.Seconds).ToString();


            livesTimer.text = "0" + hour.ToString() + ":" + min + ":" + sec;

        }
        else
        {
            PlayerPrefs.SetInt("LivesSorted", 0);
        }
    }

}
