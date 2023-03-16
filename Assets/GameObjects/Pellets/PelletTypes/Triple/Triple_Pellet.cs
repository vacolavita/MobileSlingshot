using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple_Pellet : PelletForward
{
    public int SEGMENTS = 3;
    public float spreadAngle = 30;

    public GameObject splitPellet;

    public override void Launch(Vector3 force)
    {
        float firstAngle = -spreadAngle;

        for(int i = 0; i < SEGMENTS; i++)
        {
            GameObject temp = Instantiate(splitPellet, transform.position, transform.rotation);

            temp.GetComponent<PelletForward>().Launch(Quaternion.AngleAxis(firstAngle, Vector3.forward) * force);

            firstAngle += spreadAngle;
        }

        Destroy(gameObject);
    }
}
