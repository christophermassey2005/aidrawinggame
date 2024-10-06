using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadEndCardOOP : MonoBehaviour
{
    private int round;
    // Start is called before the first frame update
    void Start()
    {
        round = Singletonattributes.Instance.roundcounter;
        UnityEngine.Debug.Log(round);

    }

    // Update is called once per frame
    void Update()
    {
        if (round >= (Singletonattributes.Instance.numberofrounds) - 1)
        {
            SceneManager.LoadScene("EndCard");

        }
    }
}
