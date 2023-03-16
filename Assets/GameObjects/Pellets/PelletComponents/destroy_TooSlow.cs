using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_TooSlow : A_ComponentBase
{
    public float threshold = 0;

    void Start()
    {
        setup();
    }

    // Update is called once per frame
    void Update()
    {
        listen();
        if (componentEnabled)
        {
            if (listener.rb.velocity.magnitude < threshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
