using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private float damage;

    private void Start()
    {
        damage = Random.Range(150f, 250f);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);  //projectile destroy itself
    }
}
