using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    //private Transform cost;
    private Text costText;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        //cost = this.gameObject.transform.GetChild(0);
        //int costV = defenderPrefab.GetComponent<Defender>().starCost;
        //cost.GetComponent<Text>().text = costV.ToString();

        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //print(name + " pressed");

        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black; 
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }
}
