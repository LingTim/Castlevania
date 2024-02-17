using UnityEngine;

public class rat_head : MonoBehaviour
{
    private rat_move rat;

    private void Start()
    {
        rat = gameObject.transform.parent.GetComponent<rat_move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground")
        {
            rat.Flip();
        }
    }
}
