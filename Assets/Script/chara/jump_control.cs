using UnityEngine;

public class jump_control : MonoBehaviour
{
    public character_move chara;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Input.GetKey(KeyCode.Space))
            chara.jump = true;
        chara.is_ground = true;
        chara.ani.SetBool("∏ı≈Dº∆≠»", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "trigger")
            return;
        else if (collision.tag == "active")
            return;
        else if (collision.tag == "gate")
            return;
        else if (collision.tag == "elevator")
            return;
        else if (collision.tag == "switch")
            return;
        else if (collision.tag == "MainCamera")
            return;
        else
        {
            chara.is_ground = true;
        }
    }
}
