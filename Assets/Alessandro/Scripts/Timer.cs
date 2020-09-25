using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] float Countdown;
    public Text myText;
    public bool over = false;
    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        string minutes = ((int)Countdown / 60).ToString();
        string seconds = (Countdown % 60).ToString("f2");
        myText.text = "Time left: " + minutes + "."+ seconds;

        if (Countdown <= 0.0f)
        {
            over = true;
        }
    }
}
