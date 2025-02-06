using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private Animation[] bgAnim;
    [SerializeField] private Animation blobAnim;

    [SerializeField] private Animator fadeAnim;
    [SerializeField] private SpriteRenderer fadeImg;

    public ChoiceBtn chcbtn;
    private void OnEnable()
    {
        for (int i = 0; i < bgAnim.Length; i++)
        {
            bgAnim[i].Play();
        }
        blobAnim.Play();
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(7.0f);
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        fadeAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeImg.color.a == 1);
        SceneManager.LoadScene(chcbtn.levelID);
        yield return null;
    }
}
