using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            anim.SetTrigger("underAttack trigger");
        }
        
    }
}
