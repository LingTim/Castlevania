using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_control : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = collision.gameObject.transform.position.x;
        //¶^¤J°w¤s
        if (x < -20.0f && x > -56.0f)
        {
            collision.gameObject.transform.position = new Vector3(-19.5f, 2.275f, 0.0f);
        }
        else if(x < 7.0f && x > 5.0f)
        {
            collision.gameObject.transform.position = new Vector3(7.5f, 4.275f, 0.0f);
        }
    }
}
