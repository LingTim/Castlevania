using UnityEngine;

public class beam : MonoBehaviour
{
    public Vector2 dir = new Vector2(1.0f, 0.0f);

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(dir * 0.1f);
    }
}
