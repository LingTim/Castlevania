using UnityEngine;
using TMPro;

[DefaultExecutionOrder(0)]
public class interact_text_control : MonoBehaviour
{
    public static interact_text_control instance;

    private TextMeshProUGUI text;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        text = GameObject.Find("¤¬°Ê¤å¦r").GetComponent<TextMeshProUGUI>();
    }

    public void text_on()
    {
        text.enabled = true;
    }

    public void text_down()
    {
        text.enabled = false;
    }
}
