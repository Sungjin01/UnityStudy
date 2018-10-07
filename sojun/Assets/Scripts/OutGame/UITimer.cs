using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

    public Text timerText;

    public void UpdateTimer(float _time)
    {
        timerText.text = string.Format("{0:F}", _time);
    }
}
