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

    private Animator anim;
    private Transform anchor = null;
    private int lastDirection = 0; // 1 is right, -1 is left, 0 is no direction

    private float lastY = 0;

	void Awake()
    {
        anim = GetComponent<Animator>();
    }

	void Update () {

        SetAnchor();

        // Move according to Anchor
        if (anchor == null)
            return;

        float ydiff = anchor.position.y - lastY;
        lastY = anchor.position.y;

        this.transform.Translate(0, -ydiff, 0);
	}

    void SetAnchor()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Climb", h);

        // set new anchor when
        // RIGHT
        if (h > threshold)
        {
            debugText.text = "Right";
            anchor = rightHand;
            anchorText.text = "Right is Anchored";
            lastDirection = 1;
            lastY = anchor.position.y;
        }
        // LEFT
        else if (h < -1 * threshold)
        {
            debugText.text = "Left";
            anchorText.text = "Left is Anchored";
            anchor = leftHand;
            lastDirection = -1;
            lastY = anchor.position.y;
        }
        else
        {
            debugText.text = "Nothing";
        }

        if (reset && h == 0) anchor = null;
    }
}
