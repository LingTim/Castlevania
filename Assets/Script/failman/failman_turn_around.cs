using UnityEngine;

public class failman_turn_around : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "���ѤH")
        {
            collision.GetComponent<failman_move>().Flip();
        }
    }
}
