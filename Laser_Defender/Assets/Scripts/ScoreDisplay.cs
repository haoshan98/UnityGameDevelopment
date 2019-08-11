using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextMeshProUGUI myText = GetComponent<TextMeshProUGUI>();
        
        myText.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
