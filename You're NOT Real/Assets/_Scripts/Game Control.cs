using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public int lives;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        // For any subsquent scene that uses GameControl
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
