using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMovement : MonoBehaviour
{
    [SerializeField] float Speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            {
                transform.Translate(Vector3.right*Time.deltaTime* Speed);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            {
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            {
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
            }
        }

    }
}
