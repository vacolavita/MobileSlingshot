using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletForward : MonoBehaviour
{
    //Y is foward.
    public Vector2 direction = Vector2.zero;

    public Rigidbody2D rb;

    //Set by the slingshot using the setLaunch function
    private float
        speed;

    public float delete_Range;

    // Start is called before the first frame update

    public void setLaunch(float rot, float strength)
    {
        direction.y = Mathf.Sin(Mathf.Deg2Rad * rot * Mathf.PI);
        direction.x = Mathf.Cos(Mathf.Deg2Rad * rot * Mathf.PI);

        speed = strength;

        Debug.Log(rot);
        Debug.Log(direction);
    }

    public void Launch(Vector3 force)
    {
        rb.velocity = force;

        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude <= delete_Range)
        {
            Destroy(gameObject);
        }
    }
}
