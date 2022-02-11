using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;

    private void Awake()
    {
        instance = this;
    }
    public void pauseGame()
    {
        Time.timeScale = 0f;
    }
    public void unPauseGame()
    {
        Time.timeScale = 1f;
    }
}
