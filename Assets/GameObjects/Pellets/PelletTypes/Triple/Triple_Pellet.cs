using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple_Pellet : PelletForward
{
    public int SEGMENTS = 3;
    public float spreadAngle = 30;

    public GameObject splitPellet;


    //I think I see the problem: When you're aiming left, the X axis of the pellet is
    //pointed in the CORRECT direction,
    //but when aiming RIGHT, the X axis of the pellet is facing the WRONG direction

    
    public override void Launch(Vector3 force)
    {
        int clutch = SEGMENTS / 2;
        float tempAngle = -spreadAngle * clutch;

        //Given how we're using lookat to control the rotation of the sprite, an overcomplicated solution
        //was needed to account for the overcomplicated setup and compensation revolved around correcting
        //the rotation of the sprite.

        //If you are aiming LEFT, spawn the balls from LEFT to RIGHT
        if (transform.position.x > toCenter.x)
        {
            Debug.Log("Aiming LEFT");

            transform.Rotate(Vector3.forward, -spreadAngle);

            for (int i = 0; i < SEGMENTS; i++)
            {
                GameObject temp = Instantiate(splitPellet, transform.position, transform.rotation);
                temp.transform.Translate(Vector3.up, Space.Self);

                transform.Rotate(Vector3.forward, spreadAngle);


                Vector3 forceDirection = Quaternion.AngleAxis(tempAngle, Vector3.forward) * force;
                temp.GetComponent<PelletForward>().Launch(forceDirection);

                tempAngle += spreadAngle;
            }
        }
        //if you are aiming RIGHT, spawn the pellets from RIGHT to LEFT
        else
        {
            Debug.Log("Aiming RIGHT");

            transform.Rotate(Vector3.forward, spreadAngle);

            for (int i = 0; i < SEGMENTS; i++)
            {
                GameObject temp = Instantiate(splitPellet, transform.position, transform.rotation);
                temp.transform.Translate(Vector3.up, Space.Self);

                transform.Rotate(Vector3.forward, -spreadAngle);

                Vector3 forceDirection = Quaternion.AngleAxis(tempAngle, Vector3.forward) * force;
                temp.GetComponent<PelletForward>().Launch(forceDirection);

                tempAngle += spreadAngle;
            }

        }
        

        Destroy(gameObject);
    }
}
