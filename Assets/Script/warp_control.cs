using UnityEngine;

public class warp_control : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown("f"))
        {
            collision.gameObject.transform.position = new Vector3(-200.0f, 19.275f, 0.0f);
        }
    }
}
