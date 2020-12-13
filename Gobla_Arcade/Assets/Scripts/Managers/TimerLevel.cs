using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerLevel : MonoBehaviour
{
    
        public float targetTime = 60.0f;
        public Text minutes, seconds;
        private int secondsText;

        public void Start()
        {
            minutes.text = "00";
        }

        public void Update()
        {
            targetTime -= Time.deltaTime;
            secondsText = (int) targetTime;
            seconds.text = ""+secondsText+"";               
            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }
        
        void timerEnded()
        {
            minutes.text = "00";
            seconds.text = "00";

            //create Ghost
        }
        
}
