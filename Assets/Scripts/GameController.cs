using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int time;
    private bool gameOver;
    private int lastEnemy;
    private string text;
    private bool paused;

    public GameObject Enemy;
    public TextMeshProUGUI textDisplay;

    // Start is called before the first frame update
    void Start()
    {
        time = (int)Time.timeSinceLevelLoad;
        textDisplay.SetText("");
        lastEnemy = (int)Time.timeSinceLevelLoad;
        paused = true;
        story();
    }

    void FixedUpdate()
    {
        if (!gameOver && !paused)
        {
            if (time - lastEnemy >= 7)
            {
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    Instantiate(Enemy, new Vector3(7.5f, -3.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(4.5f, 3.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(10.5f, 3.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-5.5f, -2.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-10.5f, -2.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-4.5f, 3.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-9.5f, 3.5f, 0f), Quaternion.identity);
                    lastEnemy = (int)Time.timeSinceLevelLoad;
                }else if(SceneManager.GetActiveScene().name == "Level2")
                {
                    Instantiate(Enemy, new Vector3(4.5f, -6.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(3.5f, 1.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(14.5f, -0.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(10.5f, 0.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(11.5f, 6.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-1.5f, 10.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-8.5f, 2.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-11.5f, -5.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-17.5f, 1.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-14.5f, 8.5f, 0f), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(-3.5f, -3.5f, 0f), Quaternion.identity);
                    lastEnemy = (int)Time.timeSinceLevelLoad;
                }
            }
            time = (int)Time.timeSinceLevelLoad;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            paused = false;
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                Instantiate(Enemy, new Vector3(7.5f, -3.5f, 0f), Quaternion.identity);
                lastEnemy = (int)Time.timeSinceLevelLoad;
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                Instantiate(Enemy, new Vector3(-11.5f, -5.5f, 0f), Quaternion.identity);
                lastEnemy = (int)Time.timeSinceLevelLoad;
            }
            textDisplay.text = "";
        }
    }

    public void endGame()
    {
        gameOver = true;
    }

    void story()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            text = "Whoah, what's going on? What is this? Man, my head is hurting... I think this is a maze or something.";
            textDisplay.text += text;
            text = " Oh, nice, I still have my pistol though. Okay, well, let's see if we can get out of here";
            textDisplay.text += text;
            text = " What the heck? Is that a chicken?? I've gotta stay away from those or they'll hurt me.";
            textDisplay.text += text;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            text = "Shoot, there's more. Well, I'm gonna keep going";
            textDisplay.text = text;
        }
    }
}