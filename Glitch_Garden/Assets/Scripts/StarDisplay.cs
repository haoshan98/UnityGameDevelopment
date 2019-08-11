using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE};

    private Text myText;
    private int totalStars = 100;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        myText.text = totalStars.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        totalStars += amount;
        myText.text = totalStars.ToString();
        print(amount + " stars added to display");
    }

    public Status UseStars(int amount)
    {
        if (totalStars >= amount)
        {
            totalStars -= amount;
            myText.text = totalStars.ToString();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
