using UnityEngine;

public class failman_melee_attack : MonoBehaviour
{
    failman_move failman;

    private void Start()
    {
        failman = transform.parent.GetComponent<failman_move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && failman.can_attack)
        {
            StartCoroutine(failman.melee_attack());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && failman.can_attack)
        {
            StartCoroutine(failman.melee_attack());
        }
    }
}
