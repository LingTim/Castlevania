using UnityEngine;

public class delete_control : MonoBehaviour
{
    public GameObject creature;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(creature);
            Destroy(gameObject);
        }
    }
}
