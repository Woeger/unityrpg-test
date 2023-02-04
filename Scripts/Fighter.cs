using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    //Defining damage variables
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    
    //Defining immunity variables
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Defining push variables
    protected Vector3 pushDirection;
    public float pushRecoverySpeed = 0.2f;

    //Function for reciving damage from damage message
    protected virtual void ReceiveDamage(Damage dmg) {

        //If fighter is not in immunity window
        if (Time.time - lastImmune > immuneTime) {

            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            //Show damage numbers
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            //If player has reached death threshold
            if (hitpoint <= 0) {
                hitpoint = 0;
                Death();
            }

        }

    }

    //Function for dying when hitpoints reach 0
    protected virtual void Death() {
    }

}
