using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Component base is the stem from which properties can be added to pellets easier.
//It contains a listener that watches the PelletForward script to make sure nothing happens
//before the pellet is shot.

//Pellet Components based off of 
public class A_ComponentBase : MonoBehaviour
{
    protected PelletForward listener;
    protected bool componentEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        setup();
    }

    //This needs to be called in the update function of the components to make them work
    //Format goes listen(); if(componentEnabled){...}
    protected void listen()
    {
        if (listener.enabled == true && componentEnabled == false)
        {
            componentEnabled = true;
        }
    }

    //Just in case later pelletComponents need to do something with start()
    protected void setup()
    {
        listener = GetComponent<PelletForward>();
    }
}
