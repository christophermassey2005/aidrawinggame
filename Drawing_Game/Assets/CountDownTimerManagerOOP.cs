
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Timer
{
    //[System.Serializable]

    public class CountDownTimerManagerOOP : MonoBehaviour
    {
        private CountDownTimerOOP Count;
        public TextMeshProUGUI text;


        void Start()
        {
            Count = new CountDownTimerOOP(text);

        }

        void Update()
        {
            Count.CountDown();
        }

    }
}
