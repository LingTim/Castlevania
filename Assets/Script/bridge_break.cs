using UnityEngine;
using System.Collections;

public class bridge_break : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            StartCoroutine(delay_break());
        }
    }

    IEnumerator delay_break()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
