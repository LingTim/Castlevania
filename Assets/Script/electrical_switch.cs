using UnityEngine;

public class electrical_switch : MonoBehaviour
{
    private bool can_use = false;
    private bool active = false;
    public bool electricity = false;

    public GameObject damaged_wall;

    public Sprite full_charge;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && can_use && !active)
        {
            active = true;
            interact_text_control.instance.text_down();
            electricity = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = full_charge;
            damaged_wall.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !active)
        {
            interact_text_control.instance.text_on();
            can_use = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !active)
        {
            interact_text_control.instance.text_down();
            can_use = false;
        }
    }
}
