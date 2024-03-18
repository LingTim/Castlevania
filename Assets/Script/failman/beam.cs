using UnityEngine;

public class beam : MonoBehaviour
{
    public Vector2 dir = new Vector2(1.0f, 0.0f);

    private character_move chara;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
        chara = GameObject.Find("еDид").GetComponent<character_move>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            chara.injury();
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(dir * 0.1f);
    }
}
