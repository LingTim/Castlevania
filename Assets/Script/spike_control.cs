using UnityEngine;

public class spike_control : MonoBehaviour
{
    private character_move chara;
    Vector3 pos;
    GameObject warp_obj;

    private void Start()
    {
        chara = GameObject.Find("¥D¨¤").GetComponent<character_move>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = collision.gameObject.transform.position.x;
        warp_obj = collision.gameObject;

        //¶^¤J°w¤s
        if (x < -20.0f && x > -56.0f)
        {
            pos = new Vector3(-19.5f, 2.275f, 0.0f);
        }
        else if(x < 7.0f && x > 5.0f)
        {
            pos = new Vector3(7.5f, 4.275f, 0.0f);
        }

        chara.injury();
        if (chara.life > 0)
            Invoke("warp_delay", 0.417f);
    }

    private void warp_delay()
    {
        warp_control.instance.warp(pos, warp_obj);
    }
}
