using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable {

    //Declaring Variables
    protected bool collected; 

    //Method to check when collectable colliades with player
    protected override void OnCollide(Collider2D coll) {
        if (coll.name == "Player")
        OnCollect();
    }

    //Method for keeping collectable state when collided (to be overridden)
    protected virtual void OnCollect() {
        collected = true;
    }

}
