using UnityEngine;
using TMPro;

public class gate : MonoBehaviour
{
    public Vector3 teleport_position;

    private bool can_teleport = false;

    private GameObject teleport_obj;

    private void Start()
    {

    }

    private void Update()
    {
        if (can_teleport && Input.GetKeyDown(KeyCode.F))
        {
            warp_control.instance.warp(teleport_position, teleport_obj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            can_teleport = true;
            teleport_obj = collision.gameObject;
            interact_text_control.instance.text_on();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            can_teleport = false;
            interact_text_control.instance.text_down();
        }
    }
}
