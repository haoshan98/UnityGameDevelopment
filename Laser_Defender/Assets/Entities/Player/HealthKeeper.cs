using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthKeeper : MonoBehaviour {

    public static float hp;
    private static TextMeshProUGUI myText;

    void Start()
    {
        hp = PlayerController.playerHealth;
        myText = GetComponent<TextMeshProUGUI>();
    }

    public static void HP(float points)
    {

        hp -= Mathf.RoundToInt(points);
        if (hp > 1000)
        {
            //myText.color = Color.HSVToRGB(133f, 41f, 95f);
            myText.color = Color.green;
            myText.text = hp.ToString();
        }
        else if(hp > 0)
        {
            myText.color = Color.red;
            myText.text = hp.ToString();
        }
        else
        {
            myText.text = "0";
        }
    }

    
}
