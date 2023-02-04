using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour {

    //Declaring variables
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    //Object can collide with at most 10 objects at any time (Possibly adjust)
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start() {
        //Get collider on start
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //Update function to check for collision
    protected virtual void Update() {

        //Take Contact filter, use it to fill Collider array
        boxCollider.OverlapCollider(filter, hits);

        //For loop, iterating over hits array
        for (int i = 0; i < hits.Length; i++) {
            if(hits[i] == null) {
                continue;
            }

            //Calling function on hit
            OnCollide(hits[i]);
            
            //Cleaning up array after iteration
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll) {

        //Logging when hit is detected
        Debug.Log(coll.name);

    }

}
