using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MatchTile.Timer
{
    public class Timer : MonoBehaviour
    {
        private float timer;

        public static UnityAction onGameOver;

        private void Start()
        {
            Setup();
        }

        private void Update()
        {
            TimerCountDown();
        }

        private void Setup()
        {
            timer = 12;
        }

        private void TimerCountDown()
        {
            if (timer <= 0)
            {
                onGameOver?.Invoke();
                return;
            }

            timer -= Time.deltaTime;
        }

        public float GetTimeLeft()
        {
            return timer;
        }
    }

}
