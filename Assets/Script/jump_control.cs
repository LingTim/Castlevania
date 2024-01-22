using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_control : MonoBehaviour
{
    public character_move chara;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Input.GetKey(KeyCode.Space))
            chara.jump = true;
        chara.is_ground = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        chara.is_ground = false;
    }
}
