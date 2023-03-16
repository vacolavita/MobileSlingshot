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

    // Start is called before the first frame update


    //This seems useless
    public virtual void setLaunch(float rot)
    {
        transform.rotation = new Quaternion(0, 0, Mathf.Deg2Rad * rot, 0);

    }

    public virtual void Launch(Vector3 force)
    {
        rb.velocity = force;

        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
