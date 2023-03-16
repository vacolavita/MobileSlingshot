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
        //direction.y = Mathf.Sin(Mathf.Deg2Rad * rot * Mathf.PI);
        //direction.x = Mathf.Cos(Mathf.Deg2Rad * rot * Mathf.PI);

        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    public virtual void Launch(Vector3 force)
    {
        rb.velocity = force;

        enabled = true;

        Debug.Log("Note for Alex: setLaunch seems obsolete consider deleting / repurposing it");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
