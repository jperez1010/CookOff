using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutScreen : MonoBehaviour
{
    public float speed = 1;

    public Image fadeOutScreen;
    private Color fadeColor = Color.black;


    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        fadeOutScreen = this.GetComponentInChildren<Image>(true);
    }

    public void ShowScreenNoDelay()
    {
        fadeColor.a = 1f;
        fadeOutScreen.color = fadeColor;
        fadeOutScreen.gameObject.SetActive(true);
    }

    public IEnumerator FadeIn()
    {
        this.GetComponent<Canvas>().sortingOrder = 10;
        float alpha = fadeOutScreen.color.a;

        fadeOutScreen.gameObject.SetActive(true);

        while (alpha < 1)
        {
            yield return new WaitForSeconds(0.01f);
            alpha += 0.01f * speed;
            fadeColor.a = alpha;
            fadeOutScreen.color = fadeColor;
        }

        this.GetComponent<Canvas>().sortingOrder = 10;
    }

    public IEnumerator FadeOut()
    {
        this.GetComponent<Canvas>().sortingOrder = 10;
        float alpha = fadeOutScreen.color.a;

        fadeOutScreen.gameObject.SetActive(true);

        while (alpha > 0)
        {
            yield return new WaitForSeconds(0.01f);
            alpha -= 0.01f * speed;
            fadeColor.a = alpha;
            fadeOutScreen.color = fadeColor;
        }
        this.GetComponent<Canvas>().sortingOrder = 0;
    }

}
