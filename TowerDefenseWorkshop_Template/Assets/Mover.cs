using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform xLeftLimit;
    [SerializeField] private Transform xRightLimit;
    [SerializeField] private Transform zUpLimit;
    [SerializeField] private Transform zDownLimit;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey("left")) || (Input.GetKey("q")))
        {
            if(transform.position.x > xLeftLimit.position.x)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
        }
        if ((Input.GetKey("right")) || (Input.GetKey("d")))
        {
            if (transform.position.x < xRightLimit.position.x)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
        if ((Input.GetKey("down")) || (Input.GetKey("s")))
        {
            if (transform.position.z > zDownLimit.position.z)
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            }
        }
        if ((Input.GetKey("up")) || (Input.GetKey("z")))
        {
            if (transform.position.z < zUpLimit.position.z)
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
    }
}
