using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = new Vector3(0.04f, -0.04f, 0f);// Speed needs to be very slow
        transform.Translate(velocity);          // Moves bullet every frame
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if(other.tag == "enemy")
        {
            other.GetComponent<EnemyController>().kill();
            Destroy(gameObject);
        }
    }
}
