using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UpdateTimeUI : MonoBehaviour
{
    public Text dayText;
    public Text timeText;

    public void UpdateDayAndTime(int day, float time)
    {
        if (dayText != null)
        {
            dayText.text = "Day " + day;
        }

        if (timeText != null)
        {
            int hours = (int)(time / 3600);
            int minutes = (int)((time % 3600) / 60);
            timeText.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
        }
    }
}
