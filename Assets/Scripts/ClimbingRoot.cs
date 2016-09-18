using UnityEngine;
using System.Collections;

public class ClimbingRoot : MonoBehaviour {

    public bool useKeys = false;

    private Animator anim;
    private float rotationZ = 0f;
    private float rotation = 0;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	void Start () {

        // Turn on Gyro
        Input.gyro.enabled = true;
	}
	
	void Update () {

        // Retrieve Gyro Value
        if (!useKeys)
        {
            rotationZ += -Input.gyro.rotationRateUnbiased.z;
            rotation = -rotationZ / 50f;
        }
        else
            rotation = Input.GetAxis("Horizontal");

        // Set Animtor
        anim.SetFloat("Climb", rotation);
	}

    public void ResetRotation()
    {
        rotationZ = 0;
    }
}
