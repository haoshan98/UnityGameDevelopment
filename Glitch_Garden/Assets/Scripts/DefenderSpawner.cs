using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    //public Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()  //need collider
    {
        //print(Input.mousePosition);
        //print("snap to grid " + SnapToGrid(CalculateWorldPointOfMouseClick()));
        Vector2 defenderPos = SnapToGrid(CalculateWorldPointOfMouseClick());
        GameObject defender = Button.selectedDefender;
        if (!defender) {
            return;
        }
        int defenderCost = defender.GetComponent<Defender>().starCost;
        //int defenderCost = GameObject.FindObjectOfType<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(defenderPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    void SpawnDefender(Vector2 defenderPos, GameObject defender)
    {
        GameObject newDefender = Instantiate(defender, defenderPos, Quaternion.identity);
        //Instantiate(Button.selectedDefender, new Vector3(defenderPos.x, defenderPos.y, 0f), Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
