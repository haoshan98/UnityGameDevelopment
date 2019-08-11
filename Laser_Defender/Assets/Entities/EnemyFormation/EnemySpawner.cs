using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f; 
    public float height = 5f;
    public float speed = 3.0f;
    public float spawnDelay = 0.5f;

    private bool goLeft = false;
    private float xmin;
    private float xmax;
   
    // Use this for initialization
    void Start () {

        SpawnUntilFull();

        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftBoundary.x;
        xmax = rightEdge.x;
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)  //freePosition exist
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity);
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }
    //Once SpawnUntilFull is done, it does not call itself again.
    //When an enemy dies after SpawnUntilFull is done, nothing gets respawned after 0.5 seconds.
    //SpawnUntilFull will gets called again if AllMembersDead returns true.

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update () {
        if (goLeft)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width); 
        float leftEdgeOfFormation = transform.position.x - (0.5f * width); 

        if(leftEdgeOfFormation <= xmin)
        {
            goLeft = false;
        }else if(rightEdgeOfFormation >= xmax)
        {
            goLeft = true;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
        
	}

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

}
 