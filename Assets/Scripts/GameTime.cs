using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    private float fixedDeltaTime;
    [SerializeField]
    private Text gameTime;
    [SerializeField]
    private Text gameMode;

    [SerializeField]
    private bool GameModeSlow;

    public bool MyGameMode { get => GameModeSlow; set => GameModeSlow = value; }

    // Start is called before the first frame update
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        GameModeSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale -= 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale += 0.25f;
        }

        if (MyGameMode)
        {
            if (true)
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (MyGameMode == true)
            {
                MyGameMode = false;
                gameMode.text = "Game Mode: Normal";
                Time.timeScale = 1f;
            }
            else
            {
                MyGameMode = true;
                gameMode.text = "Game Mode: Slow";
                Time.timeScale = 0.5f;
            }
            
        }

        gameTime.text = Time.timeScale.ToString() + "x";
        Time.fixedDeltaTime = fixedDeltaTime;
    }
}
