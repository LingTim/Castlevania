using UnityEngine;

public class jump_control : MonoBehaviour
{
    public character_move chara;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Input.GetKey(KeyCode.Space))
            chara.jump = true;
        chara.is_ground = true;
        chara.ani.SetBool("∏ı≈Dº∆≠»", false);
        
    }
}
