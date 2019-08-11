using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator anim;
    private Spawner myLaneSpwaner;

    void Awake()
    {
        projectileParent = GameObject.Find("Projectiles"); //find it in scene when run

        if (!projectileParent)
        {  //if doesn't exist, create ourself
            projectileParent = new GameObject("Projectiles");
            //Debug.Log(projectileParent);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();

        SetMyLaneSpwaner();
        print(myLaneSpwaner);
    }

    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    //Look thru all spawners, and set myLaneSpwaner if found
    void SetMyLaneSpwaner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner thisSpawner in spawnerArray)
        {
            if (thisSpawner.transform.position.y == transform.position.y)
            {
                myLaneSpwaner = thisSpawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        //Exit if no attackers in lane
        if (myLaneSpwaner.transform.childCount <= 0)
        {
            return false;
        }

        //If there are attackers, are they ahead?
        foreach(Transform child in myLaneSpwaner.transform)
        {   //the child is refer to attacker
            if(child.transform.position.x <= 9 && child.transform.position.x >= transform.position.x)
            {
                return true;
            }
        }
        //Attacker in lane but behind us
        return false;
        
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);  //Instantiate is creating a prefab
        newProjectile.transform.parent = projectileParent.transform;
        //newProjectile obeying childed to the projectileParent GameObject

        //newProjectile.transform.parent = this.transform;

        newProjectile.transform.position = gun.transform.position;
    }

}
