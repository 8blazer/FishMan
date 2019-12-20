using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingLight : MonoBehaviour
{
    bool swingRight = true;
    public float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(0, 0, rotation);
        if (swingRight == true)
        {
            if (transform.rotation.eulerAngles.z > 180)
            {
                rotation = rotation - .01f;
                if (rotation < 0)
                {
                    swingRight = false;
                }
            }
            else
            {
                rotation = rotation + .01f;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z > 180)
            {
                rotation = rotation - .01f;
                if (rotation > 0)
                {
                    swingRight = true;
                }
            }
            else
            {
                rotation = rotation + .01f;
            }
        }
    }
}