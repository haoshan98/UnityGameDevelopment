using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int starCost = 100;  //the price of the defender

    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    //this method called from the animation
    public void AddStars(int amount)
    {  //then pass the value to text diaplay thru StarDisplay.cs AddStars method
        starDisplay.AddStars(amount);
    }
}
