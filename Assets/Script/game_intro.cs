using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class game_intro : MonoBehaviour
{
    private int intro_counter = 0;
    private int intro_number = 0;

    private Image intro;

    public Sprite[] intro_image;
    private CanvasGroup start_button;

    private void Start()
    {
        intro = GameObject.Find("開頭動畫").GetComponent<Image>();
        start_button = GameObject.Find("開始按鈕").GetComponent<CanvasGroup>();
    }

    private void FixedUpdate()
    {
        intro_counter++;
        if (intro_counter % 5 == 0 && intro_number < intro_image.Length)
        {
            intro_counter = 0;
            intro.sprite = intro_image[intro_number];
            intro_number++;
            if (intro_number == intro_image.Length)
                StartCoroutine(button_appear());
        }
    }

    IEnumerator button_appear()
    {
        for(int i = 0;i < 10;i++)
        {
            yield return new WaitForSeconds(0.1f);
            start_button.alpha += 0.1f;
        }
        start_button.interactable = true;
        start_button.blocksRaycasts = true;
    }

    public void start_game()
    {
        SceneManager.LoadScene("game_scene");
    }
}
