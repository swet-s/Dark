using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Timer
{
    public static TimeSpan GetTimeSpan()
    { 
        return DateTime.Now - GetOldTime();
    }



    public static void RecordTime()
    {
        int year = DateTime.Now.Year;
        PlayerPrefs.SetInt("Year", year);

        int month = DateTime.Now.Month;
        PlayerPrefs.SetInt("Month", month);

        int day = DateTime.Now.Day;
        PlayerPrefs.SetInt("Day", day);

        int hours = DateTime.Now.Hour;
        PlayerPrefs.SetInt("Hour", hours);

        int mins = DateTime.Now.Minute;
        PlayerPrefs.SetInt("Minute", mins);

        int sec = DateTime.Now.Minute;
        PlayerPrefs.SetInt("Second", sec);

        PlayerPrefs.Save();
    }

    public static DateTime GetOldTime()
    {
        int y = PlayerPrefs.GetInt("Year", DateTime.Now.Year);
        int mo= PlayerPrefs.GetInt("Month", DateTime.Now.Month);
        int d = PlayerPrefs.GetInt("Day", DateTime.Now.Day);
        int h = PlayerPrefs.GetInt("Hour", DateTime.Now.Hour);
        int m = PlayerPrefs.GetInt("Minute", DateTime.Now.Minute);
        int s = PlayerPrefs.GetInt("Second", DateTime.Now.Second);


        return new DateTime(y, mo, d, h, m, s);
    }

}