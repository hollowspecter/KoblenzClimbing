using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {

    float xRotation;
    float yRotation;
    float zRotation;

    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //xRotation += -Input.gyro.rotationRateUnbiased.x;
        //yRotation += -Input.gyro.rotationRateUnbiased.y;

        zRotation += -Input.gyro.rotationRateUnbiased.z;

        transform.eulerAngles = new Vector3(0, 0, zRotation);

       // MoveCharacter();
    }

    public void reset_angle()
    {
        zRotation = 0;
    }

    public float getNumber()
    {
        return -zRotation / 50f;
    }

    //public void MoveCharacter()
    //{
    //    if (Swipe.Instance.IsSwiping(SwipeDirection.Left))
    //    {
    //        transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
    //    }
    //    if (Swipe.Instance.IsSwiping(SwipeDirection.Right))
    //    {
    //        transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
    //    }

    //}
}

