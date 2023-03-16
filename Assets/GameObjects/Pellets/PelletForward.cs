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
    public void setLaunch(Transform rot)
    {
        transform.LookAt(rot, Vector3.left);
        transform.Rotate(Vector3.up, 90, Space.Self);
        transform.Rotate(Vector3.forward, 90, Space.Self);

        transform.rotation.Set(0, 0, transform.rotation.z, transform.rotation.w);

        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
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
