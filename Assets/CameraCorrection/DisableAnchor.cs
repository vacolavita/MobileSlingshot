using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CameraAnchor))]
public class DisableAnchor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraAnchor anchor = GetComponent<CameraAnchor> ();


        anchor.enabled = false;
        anchor.StopAllCoroutines ();
    }

    // Update is called once per frame

}
