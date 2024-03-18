using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(0)]
public class bloodUI_control : MonoBehaviour
{
    public static bloodUI_control instance;

    private int head_counter = 0;
    private int head_number = 0;

    private Image blood;
    private Image head;

    public Sprite[] blood_image;
    public Sprite[] head_image;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        blood = GameObject.Find("血條").GetComponent<Image>();
        head = GameObject.Find("腳色頭像").GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        head_counter++;
        if(head_counter % 7 == 0)
        {
            head_counter = 0;
            head_number = (head_number + 1) % 14;
            head.sprite = head_image[head_number];
        }
    }

    public void bloodUI_change(int num)
    {
        blood.sprite = blood_image[num / 10];
    }    
}
