using UnityEngine;

public class void_damage : MonoBehaviour
{
    public Vector3 teleport_position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<character_move>().injury();
            warp_control.instance.warp(teleport_position, collision.gameObject, false);
        }
    }
}
