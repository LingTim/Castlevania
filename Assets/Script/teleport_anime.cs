using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class teleport_anime : MonoBehaviour
{
    public Sprite[] screens;

    private Image screen;

    private Rigidbody2D chara_rigid_body;

    private void Start()
    {
        screen = gameObject.GetComponent<Image>();
    }

    public void test()
    {
        StartCoroutine(screen_anime());
    }

    public IEnumerator screen_anime()
    {
        chara_rigid_body = GameObject.Find("еDид").GetComponent<Rigidbody2D>();
        chara_rigid_body.gravityScale = 0;
        chara_rigid_body.velocity = new Vector2(chara_rigid_body.velocity.x, 0);
        for(int i = 0;i < screens.Length;i++)
        {
            if(5 <= i && i <= 9)
                yield return new WaitForSeconds(0.1f);
            else
                yield return new WaitForSeconds(0.05f);
            screen.sprite = screens[i];
        }
        chara_rigid_body.gravityScale = 5;
    }
}
