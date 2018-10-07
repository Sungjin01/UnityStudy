using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEndGame : MonoBehaviour {

    public Text scoreText;


    public void Open(int _score)
    {
        gameObject.SetActive(true);
        scoreText.text = string.Format("{0:D}", _score);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void OnRestat()
    {
        SceneController.instance.Load("test");
    }
    public void Onmain()
    {
        SceneController.instance.Load("Main");
    }

}
