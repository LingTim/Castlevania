using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(0)]
public class bloodUI_control : MonoBehaviour
{
    public static bloodUI_control instance;

    private int head_counter = 0;
    private int head_number = 0;
    private int prologue_number = 0;

    private bool is_play = false;

    private Image blood;
    private Image head;
    private Image prologue;

    public Sprite[] blood_image;
    public Sprite[] head_image;
    public Sprite[] prologue_image;

    public Canvas death_canvas;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        blood = GameObject.Find("血條").GetComponent<Image>();
        head = GameObject.Find("腳色頭像").GetComponent<Image>();
        prologue = GameObject.Find("序章標題動畫").GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        head_counter++;
        if(head_counter % 7 == 0)
        {
            head_counter = 0;
            head_number = (head_number + 1) % head_image.Length;
            head.sprite = head_image[head_number];
        }
    }

    public void bloodUI_change(int num)
    {
        if (num < 0)
            return;
        blood.sprite = blood_image[num / 10];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!is_play)
        {
            StartCoroutine(prologue_anime());
            is_play = true;
        }
    }

    IEnumerator prologue_anime()
    {
        while(prologue_number < prologue_image.Length)
        {
            yield return new WaitForSeconds(0.1f);
            prologue.sprite = prologue_image[prologue_number];
            prologue_number++;
        }
    }

    public void death_canvas_appear()
    {
        death_canvas.enabled = true;
    }

    public void load_intro()
    {
        SceneManager.LoadScene("intro_scene");
    }
}
