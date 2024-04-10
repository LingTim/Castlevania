using UnityEngine;

public class up_to_down_warp : MonoBehaviour
{
    public Vector3 teleport_position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            warp_control.instance.warp(teleport_position, collision.gameObject, true);
        }
    }
}
