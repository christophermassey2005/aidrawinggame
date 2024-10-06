using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Timer
{
    public class CountDownTimerOOP_GM2_Manager : MonoBehaviour
    {
        private CountDownTimerOOP_GM2 Count2;
        public TextMeshProUGUI text;

        // Start is called before the first frame update
        void Start()
        {
            Count2 = new CountDownTimerOOP_GM2(text);

        }

        // Update is called once per frame
        void Update()
        {
            Count2.CountDown();

        }
    }
}

