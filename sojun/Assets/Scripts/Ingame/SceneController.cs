using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static SceneController instance;

    void Awake()
    {
        instance = this;
    }

    public void Load(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
