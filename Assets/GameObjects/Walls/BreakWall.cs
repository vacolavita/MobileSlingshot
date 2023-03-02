using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BreaksWalls"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Sticky"))
        {
            Debug.Log("Sticky");
            rb.velocity = new Vector2(rb.velocity.x * 0.6f, rb.velocity.y * 0.6f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
