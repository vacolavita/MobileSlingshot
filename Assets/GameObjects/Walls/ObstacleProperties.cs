using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleProperties : MonoBehaviour
{
    [Tooltip("Controls whether this obstacle can be moved around by physics.")]
    public bool pushable = false;
    [Tooltip("Controls whether this obstacle can destroy any pushable, non-invincible objects it touches.")]
    public bool evil = false;
    [Tooltip("Controls whether this obstacle can be destroyed by any object.")]
    public bool breakable = false;
    [Tooltip("Controls whether this obstacle is immune to destruction.")]
    public bool invincible = false;
    [Tooltip("Controls the velocity multiplier this obstacle will apply to pushable objects that touch it.")]
    public float bounciness = 1;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (pushable)
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        else {
            if (pushable)
            {
                Debug.Log("Missing Rigidbody2D");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ObstacleProperties>() != null)
        {
            ObstacleProperties properties = collision.gameObject.GetComponent<ObstacleProperties>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x * bounciness, rb.velocity.y * bounciness);

            if (properties != null && !invincible) {
                if (properties.evil || breakable) {
                    Destroy(gameObject);

                    GameObject breaksound = GameObject.Find("Break");
                    if (breaksound != null)
                    {
                        AudioSource sound = breaksound.GetComponent<AudioSource>();
                        sound.Play();
                    }
                }
            }

            GameObject hitsound = GameObject.Find("Hit");
            if (hitsound != null)
            {
                AudioSource sound = hitsound.GetComponent<AudioSource>();
                sound.Play();
            }
        }
    }
}