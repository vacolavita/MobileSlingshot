using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletForward : MonoBehaviour
{
    //Y is foward.
    public Vector2 direction = Vector2.zero;

    public Rigidbody2D rb;

    //Used for triple pellets knowing whether or not the user is shooting right or left
    protected Vector3 toCenter;

    //Set by the slingshot using the setLaunch function
    private float
        speed;

    // Start is called before the first frame update


    public void setLaunch(Transform rot)
    {
        toCenter = rot.position; //se variable declaration

        transform.LookAt(rot);

        transform.Rotate(Vector3.up, 90, Space.Self);
        transform.Rotate(Vector3.forward, 90, Space.Self);
        transform.rotation.Set(0, 0, transform.rotation.z, 0);

        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
    }

    public virtual void Launch(Vector3 force)
    {
        rb.velocity = force;

        enabled = true;
        TrailRenderer tr = GetComponent<TrailRenderer>();
        if(tr != null)
            tr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
