using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isLevelComplete = false;
    public GameObject levelCompletePanel;

    void Start()
    {
        Time.timeScale = 1;
        levelCompletePanel.SetActive(false);    
    }

    void Update()
    {
        if(isLevelComplete)
        {
            Time.timeScale = 0;
            levelCompletePanel.SetActive(true);
        }
    }
}
