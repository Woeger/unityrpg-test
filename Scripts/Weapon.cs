using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable {

    //Damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //Weapon upgrades
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Attack
    private float cooldown = 0.5f;
    private float lastSwing;

    //Setting up hitbox as per collidable
    protected override void Start() {

        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    //Checking if player is trying to attack, if player is trying to attack, see if cooldown has expired, if player can attack, run attack method
    protected override void Update() {

        if(Input.GetKeyDown(KeyCode.Space)) {

            if(Time.time - lastSwing > cooldown) { 
                lastSwing = Time.time;
                Swing();
            }

        }

    }

    //Overriding OnCollide to give behaviour on hit
    protected override void OnCollide(Collider2D coll) {
        
        if (coll.tag == "Fighter") {

            //Returning if weapon collides with the player - No friendly fire!
            if (coll.name == "Player") {
                return;
            }

            //Otherwise if anything else hittable is collided with, create a new damage object with details of the hit
            Damage dmg = new Damage {

                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce

            };

            coll.SendMessage("ReceiveDamage", dmg);

        }

    }

    //Attack method
    private void Swing() {
        Debug.Log("Swing!");
    }

}
