using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, Random.Range(0, 360));

            GameObject t_bullet = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            PelletForward t_script = t_bullet.GetComponent<PelletForward>();

            t_script.setLaunch(transform.rotation.eulerAngles.z, Random.Range(0, 15));

            t_script.Launch();
        }

    }
}
