using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    public Image[] imgs;
    public TextMeshProUGUI[] texts;
    public Button[] buttons;

    public Image[] levelImgs;
    public TextMeshProUGUI[] levelTexts;
    public Button[] levelButtons;

    public void Play()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            for (int j = 0; j < imgs.Length; j++)
            {
                imgs[j].color = new Color(imgs[j].color.r, imgs[j].color.g, imgs[j].color.b, i);
            }
            for (int j = 0; j < texts.Length; j++)
            {
                texts[j].color = new Color(texts[j].color.r, texts[j].color.g, texts[j].color.b, i);
            }

            for (int j = 0; j < levelButtons.Length; j++)
            {
                levelButtons[j].interactable = true;
                levelButtons[j].gameObject.SetActive(true);
            }

            StartCoroutine(FadeIn());
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            for (int j = 0; j < levelImgs.Length; j++)
            {
                levelImgs[j].color = new Color(levelImgs[j].color.r, levelImgs[j].color.g, levelImgs[j].color.b, i);
            }
            for (int j = 0; j < levelTexts.Length; j++)
            {
                levelTexts[j].color = new Color(levelTexts[j].color.r, levelTexts[j].color.g, levelTexts[j].color.b, i);
            }
            yield return null;
        }
    }
}
