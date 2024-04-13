using UnityEngine;

public class void_damage : MonoBehaviour
{
    public Vector3 teleport_position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<character_move>().injury(10);
            if(collision.GetComponent<character_move>().life > 0)
            {
                warp_control.instance.warp(teleport_position, collision.gameObject, false);
            }
            else
            {
                collision.GetComponent<Rigidbody2D>().gravityScale = 0;
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
