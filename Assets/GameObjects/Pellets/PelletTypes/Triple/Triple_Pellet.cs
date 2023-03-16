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
        Debug.Log(transform.rotation.z);
        float firstAngle = (Mathf.Rad2Deg * transform.rotation.z) - ((SEGMENTS / 2) * spreadAngle);


        transform.rotation = Quaternion.Euler(0, 0, firstAngle);

        for(int i = 0; i < SEGMENTS; i++)
        {
            GameObject temp = Instantiate(splitPellet, transform.position, transform.rotation);
            
            temp.transform.Translate(Vector3.forward * 2);
            transform.Rotate(0, 0, firstAngle);

            temp.GetComponent<PelletForward>().Launch(force);
        }

        Destroy(gameObject);
    }
}
