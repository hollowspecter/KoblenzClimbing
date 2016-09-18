using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    float zRotation;

    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

        zRotation += -Input.gyro.rotationRateUnbiased.z;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360-zRotation);

    }

    public void reset_angle()
    {
        zRotation = 0;
    }

    public float getNumber()
    {
        return -zRotation / 50f;
    }
}
