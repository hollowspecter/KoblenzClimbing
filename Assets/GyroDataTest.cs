using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GyroDataTest : MonoBehaviour {

    public Transform handy;
    public Text rotationText;

    private Text gyroText;

    private Quaternion origin_attitude = Quaternion.identity;

    void Awake()
    {
        gyroText = GetComponent<Text>();
    }

    void Start()
    {
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        // Gyroscrope
        Quaternion att = Quaternion.Inverse(Input.gyro.attitude) * origin_attitude;
        Vector3 euler = att.eulerAngles;
        //Input.gyro.
        gyroText.text = "X:" + euler.x + ";\nY:" + euler.y + ";\nZ:" + euler.z;
        handy.rotation = att;

        //Accelerometer
        Vector3 rot = Input.gyro.rotationRate;
        rotationText.text = "X:" + rot.x + "\nY:" + rot.y + "\nZ:" + rot.z;
    }

    public void Calibrate()
    {
        origin_attitude = Input.gyro.attitude;
    }
}
