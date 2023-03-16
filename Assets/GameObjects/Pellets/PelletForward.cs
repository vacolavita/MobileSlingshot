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
    public void setLaunch(float rot)
    {
        transform.rotation = Quaternion.Euler(0, 0, rot);
        Debug.Log("Launch being set");
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
