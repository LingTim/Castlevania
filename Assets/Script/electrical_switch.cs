using UnityEngine;

public class electrical_switch : MonoBehaviour
{
    private bool can_use = false;
    private bool active = false;

    private GameObject[] elevators;

    public Sprite full_charge;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && can_use && !active)
        {
            elevators = GameObject.FindGameObjectsWithTag("elevator");

            foreach(GameObject e in elevators)
            {
                e.GetComponent<elevator>().electricity = true;
            }

            active = true;
            interact_text_control.instance.text_down();

            gameObject.GetComponent<SpriteRenderer>().sprite = full_charge;
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
