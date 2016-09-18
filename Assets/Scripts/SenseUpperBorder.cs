using UnityEngine;
using System.Collections;

public class SenseUpperBorder : MonoBehaviour {

    public Transform upperBorder;
    public float lengthUpAnim = 3f;

    private Animator anim;
    private Transform sensor;

    private bool reachedBorder = false;
    private bool sensorFound = true;
    private bool pullingUp = false;

    private float timer = 0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sensor = transform.FindChild("senseUpperBorder");

        if (sensor == null)
        {
            print("There is no sensor found!");
            sensorFound = false;
        }
    }
	
	void Update () {
        if (!sensorFound)
            return;

	    if (sensor.position.y >= upperBorder.position.y && !reachedBorder)
        {
            print("You've reached the upper border");
            reachedBorder = true;
            anim.SetTrigger("Up");
        }

        if (reachedBorder && !pullingUp)
        {
            timer += Time.deltaTime;

            if (timer >= lengthUpAnim)
            {
                anim.SetTrigger("Flag");
                pullingUp = true;
            }
        }
	}
}
