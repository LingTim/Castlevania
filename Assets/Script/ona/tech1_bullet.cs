using UnityEngine;

public class tech1_bullet : MonoBehaviour
{
    private Vector2 dir = new Vector2(1.0f, 0.0f);

    private character_move chara;

    private GameObject ona;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
        chara = GameObject.Find("¥D¨¤").GetComponent<character_move>();
        ona = GameObject.Find("¼Ú®R");
        if (transform.position.x < ona.transform.position.x)
        {
            dir *= -1;
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(dir * 0.2f);
    }

    public void Flip()
    {
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;
    }
}
