using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceBtn : MonoBehaviour
{
    public Image[] imgs;
    public TextMeshProUGUI[] texts;
    public Button[] buttons;

    public GameObject animationObj;
    public GameObject fadeObj;

    [SerializeField] private Animation oakAnim;
    [SerializeField] private Animation mapleAnim;
    [SerializeField] private GameObject wisteriaTree;
    [SerializeField] private GameObject oakTree;
    [SerializeField] private GameObject mapleTree;
    [SerializeField] private GameObject oakBg;
    [SerializeField] private GameObject mapleBg;
    [SerializeField] private GameObject wisteriaBg;
    [SerializeField] private GameObject originalBg;

    public int levelID = 2;

    public void Play(Button btn)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        switch(btn.name)
        {
            case "Oak":
                oakAnim.Play();
                wisteriaTree.SetActive(false);
                StartCoroutine(FadeOut(0));
                levelID = 3;
                break;
            case "Maple":
                mapleAnim.Play();
                wisteriaTree.SetActive(false);
                levelID = 1;
                StartCoroutine(FadeOut(1));
                break;
            default:
                StartCoroutine(FadeOut(2));
                break;
        }
    }

    IEnumerator FadeOut(int type)
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

            animationObj.SetActive(true);
            fadeObj.SetActive(true);
            originalBg.SetActive(false);
            if(type == 0)
                oakBg.SetActive(true);
                oakTree.SetActive(false);
            if (type == 1)
                mapleBg.SetActive(true);
                mapleTree.SetActive(false);
            if (type == 2)
                wisteriaBg.SetActive(true);
                wisteriaTree.SetActive(false);
            yield return null;
        }
    }
}
