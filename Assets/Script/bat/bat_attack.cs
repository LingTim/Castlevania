using UnityEngine;

public class bat_attack : MonoBehaviour
{
    private bat_move bat;

    private void Start()
    {
        bat = transform.parent.GetComponent<bat_move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            bat.dive = true;
    }
}
