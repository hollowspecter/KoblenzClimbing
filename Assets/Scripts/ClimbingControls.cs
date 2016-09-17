using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClimbingControls : MonoBehaviour {

    public Text debugText;
    public Text anchorText;
    public float threshold = 0.4f;
    public Transform leftHand;
    public Transform rightHand;
    public bool reset = false;

    public Rotating rotatingScript;

    private Animator anim;
    private Transform anchor = null;
    private float rotationZ = 0f;

    private float lastY = 0;

	void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        // Turn on Gyro
        Input.gyro.enabled = true;
    }

	void Update () {
        // Retrieve Gyro Value
        rotationZ += -Input.gyro.rotationRateUnbiased.z;
        float rot = -rotationZ / 50f;

        SetAnchor(rot);

        Movement();
	}

    void SetAnchor(float h)
    {
        //float h = Input.GetAxis("Horizontal"); //old tastatur
        //float h = rotatingScript.getNumber();

        anim.SetFloat("Climb", h);

        // set new anchor when
        // RIGHT
        if (h > threshold)
        {
            debugText.text = "Right";
            anchor = rightHand;
            anchorText.text = "Right is Anchored";
            lastY = anchor.position.y;
        }
        // LEFT
        else if (h < -1 * threshold)
        {
            debugText.text = "Left";
            anchorText.text = "Left is Anchored";
            anchor = leftHand;
            lastY = anchor.position.y;
        }
        else
        {
            debugText.text = "Nothing";
        }

        if (reset && h == 0) anchor = null;
    }

    void Movement()
    {
        // Move according to Anchor
        if (anchor == null)
            return;

        float ydiff = anchor.position.y - lastY;
        lastY = anchor.position.y;

        if (ydiff < 0)
            this.transform.Translate(0, -ydiff, 0);
    }
}
