using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime = 5f;

    private Image fadePanel;
    private Color colorToFadeTo;
    private Color currentColor = Color.black;

    void Start()
    {
        fadePanel = GetComponent<Image>();
        
        //colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        //fadePanel.CrossFadeColor(colorToFadeTo, fadeInTime, true, true);
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad < fadeInTime)
        {   //fade in
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
            //Debug.Log(currentColor.a);
        }
        else
        {   //deactivate Panel to be able to click anything
            gameObject.SetActive(false);
        }
    }
    //gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.5f);

    //FadeIn YourPanel.color = new Color(0.0f, 0.0f, 0.0f, Mathf.Lerp (YourPanel.color.a, 0.0f, Time.deltaTime* 1.1f));

    //FadeOut YourPanel.color = new Color(0.0f, 0.0f, 0.0f, Mathf.Lerp (YourPanel.color.a,235/255f, Time.deltaTime* 1.1f));

}
