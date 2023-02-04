using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    //Transform to focus camera
    public Transform lookAt;
    //Boundary before camera starts moving
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    //Late update so camera updates after player.cs finishes moving
    private void LateUpdate() {

        //Create new vector, zero value.
        Vector3 delta = Vector3.zero;

        //Checking to see if camera is outside of boundary on the X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) {
            //Check to see if camera is outside on the left or right and adjust accordingly
            if(transform.position.x < lookAt.position.x) {
                delta.x = deltaX - boundX;
            } else {
                delta.x = deltaX + boundX;
            }
        }

        //Same checks, but for the Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) {
            if(transform.position.y < lookAt.position.y) {
                delta.y = deltaY - boundY;
            } else {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

}
