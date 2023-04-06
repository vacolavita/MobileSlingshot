using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackForth : MonoBehaviour
{
    public float speed = 3f;
    bool switc = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(switc){
            moveObjectRight();
        }
        if(!switc){
            moveObjectLeft();
        }
        if(transform.position.x >= 1f){
            switc = false;
        }
        if(transform.position.x <= -1f){
            switc = true;
        }
    }

    void moveObjectLeft(){
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void moveObjectRight(){
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
