using UnityEngine;

public class tech3_bullet : MonoBehaviour
{
    private Vector2 dir = new Vector2(0.0f, 1.0f);

    private character_move chara;

    private void Start()
    {
        chara = GameObject.Find("еDид").GetComponent<character_move>();
        Destroy(gameObject, 0.5f);
    }

    private void FixedUpdate()
    {
        transform.Translate(dir * 0.12f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
