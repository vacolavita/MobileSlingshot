using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounces : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sticky"))
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.4f, rb.velocity.y * 0.4f);
        }
        if (collision.gameObject.CompareTag("Bouncy"))
        {
            rb.velocity = new Vector2(rb.velocity.x * 1.3f, rb.velocity.y * 1.3f);
        }
    }
}
