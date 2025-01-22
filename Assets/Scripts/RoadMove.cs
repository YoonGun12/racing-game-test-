using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    public float objMoveSpeed;


    private void Update()
    {
        transform.position -= Vector3.forward * (objMoveSpeed * Time.deltaTime);

        if (transform.position.z <= -21.5f)
        {
            if (gameObject.CompareTag("Gas"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 21.5f);
            }
        }
    }

    
}
