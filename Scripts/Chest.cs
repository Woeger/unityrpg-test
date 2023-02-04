using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable {

    public Sprite emptyChest;
    public int goldAmount = 10;

    //Overriding OnCollect for chest specific logic
    protected override void OnCollect() {
        
        if (!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Display floating text showing amount
            GameManager.instance.ShowText("+" + goldAmount + " gold!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
    
}
