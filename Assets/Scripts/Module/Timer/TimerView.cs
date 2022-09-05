using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MatchTile.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;

        private Timer timer;
        private int minutes;
        private int seconds;

        private void Start()
        {
            timer = FindObjectOfType<Timer>();
        }

        private void Update()
        {
            minutes = (int)(timer.GetTimeLeft() / 60);
            seconds = (int)(timer.GetTimeLeft() % 60);

            if(minutes < 10 && seconds < 10)
            {
                timerText.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
            } 
            else if(minutes < 10)
            {
                timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
            }
            else if(seconds < 10)
            {
                timerText.text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                timerText.text = minutes.ToString() + ":" + seconds.ToString();
            }
        }
    }

}
