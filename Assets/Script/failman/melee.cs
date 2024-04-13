using UnityEngine;

public class melee : MonoBehaviour
{
    private character_move chara;

    private void Start()
    {
        chara = GameObject.Find("�D��").GetComponent<character_move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            chara.injury(10);
            chara.beat_back(chara.transform.position.x, transform.parent.position.x);
        }
    }
}
