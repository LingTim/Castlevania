using UnityEngine;

public class character_attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "villain")
        {
            if (collision.name == "¦Ñ¹«")
            {
                rat_move rat = collision.GetComponent<rat_move>();
                rat.be_damaged();
            }
            else if(collision.name == "½¿½»")
            {
                bat_move bat = collision.GetComponent<bat_move>();
                bat.be_damaged();
            }
            else if (collision.name == "¥¢±Ñ¤H")
            {
                failman_move failman = collision.GetComponent<failman_move>();
                failman.be_damaged();
            }
        }
    }
}
