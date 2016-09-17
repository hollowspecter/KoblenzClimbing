using UnityEngine;
using System.Collections;

public class SenseUpperBorder : MonoBehaviour {

    public Transform upperBorder;

    private Animator anim;
    private Transform sensor;

    private bool reachedBorder = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sensor = transform.FindChild("senseUpperBorder");
    }
	
	void Update () {
	    if (sensor.position.y >= upperBorder.position.y && !reachedBorder)
        {
            Debug.Log("You've reached the upper border");
            reachedBorder = true;
            anim.SetTrigger("Up");
        }
	}
}
