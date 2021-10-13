using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private int time;
    private Vector3 velocity;
    private SpriteRenderer rend;
    private Animator anim;
    public bool dead;

    // Use this for initialization
    void Start()
    {
        dead = false;
        velocity = new Vector3(-0.01f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            //get the width of the object
            float width = rend.bounds.size.x;
            float height = rend.bounds.size.y;

            //1% of the time, switch the direction: 
            int change = Random.Range(0, 100);
            if (change == 0)
            {
                velocity = new Vector3(-velocity.x, -velocity.y, 0);
            }
            //1% of the time, switch from horizontal to vertical, or vice-versa: 
            else if (change == 1)
            {
                if (velocity.x != 0f)
                    velocity = new Vector3(0f, velocity.x, 0f);
                else
                    velocity = new Vector3(velocity.y, 0f, 0f);
            }
            transform.Translate(velocity);


            if (velocity.x != 0)
            {
                anim.Play("MoveLeftRight");
            }
            else if (velocity.y > 0)
            {
                anim.Play("MoveUp");
            }
            else if (velocity.y < 0)
            {
                anim.Play("MoveDown");
            }
        }
    }

    public void kill()
    {
        dead = true;
        anim.speed = 1f;
        anim.Play("Die");
        Destroy(gameObject, 0.3f);
    }
}
