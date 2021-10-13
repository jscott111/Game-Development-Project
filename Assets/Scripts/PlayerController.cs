using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;
    private float AngleRad;
    private float AngleDeg;
    private float playerAngle;
    private SpriteRenderer rend;
    private bool gameOver;

    public GameObject gameController;
    public Slider slider;
    public GameObject Bullet;
    public Button playAgainButton;
    public Text winText;
    public Text loseText;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        slider.value = 10;
        gameOver = false;
        playAgainButton.gameObject.SetActive(false);
        playAgainButton.interactable = false;
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameOver)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
            velocity = new Vector3(Input.GetAxis("Vertical") * 0.03f, Input.GetAxis("Horizontal") * -0.03f, 0f);
            transform.Translate(velocity);          // Controls player movement around map

            AngleRad = Mathf.Atan2(Input.mousePosition.y - Screen.height / 2, Input.mousePosition.x - Screen.width / 2);// Offsets were found by printing mousePosition at the player point
            AngleDeg = (180 / Mathf.PI) * AngleRad;  // Controls player rotation to always look at cursor position
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            Camera.main.transform.rotation = Quaternion.identity;// Keep camera from rotating with player
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = Instantiate(Bullet, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);

                bullet.transform.rotation = this.transform.rotation;// Set the rotation to be the same as the angle of the player
                bullet.transform.Rotate(0, 0, 45);                  // Still needs an offset of 45 because the sprite is at a 45 degree angle
            }
            if (slider.value == 0)
            {
                gameOver = true;
                gameLose();
                gameController.GetComponent<GameController>().endGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "enemy" && col.gameObject.GetComponent<EnemyController>().dead == false)
        {
            slider.value--;
        }
        else if(col.gameObject.tag == "end")
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                gameWin();
            }
        }
    }

    void gameWin()
    {
        winText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        playAgainButton.interactable = true;
        gameOver = true;
    }

    void gameLose()
    {
        loseText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        playAgainButton.interactable = true;
        gameOver = true;
    }
}
