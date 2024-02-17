using UnityEngine;

public class rat_attack : MonoBehaviour
{
    private rat_move rat;

    private void Start()
    {
        rat = gameObject.transform.parent.GetComponent<rat_move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && rat.can_attack)
        {
            rat.attacking = true;
            rat.can_attack = false;
            StartCoroutine(rat.attack());
        }
    }
}
