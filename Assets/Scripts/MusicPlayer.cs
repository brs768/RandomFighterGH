using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyObject(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

}
