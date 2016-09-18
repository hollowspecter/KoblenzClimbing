using UnityEngine;
using System.Collections;

public class SwipeMoving : MonoBehaviour {

    float jumpingDistance;
    
	// Use this for initialization
	void Start () {
        jumpingDistance = 5f;
    }
	
	// Update is called once per frame
	void Update () {
        SwipeJump();
    }

    public void SwipeJump()
    {
        if (Swipe.Instance.IsSwiping(SwipeDirection.Left))
        {
            MoveOnX(jumpingDistance);
        }
        if (Swipe.Instance.IsSwiping(SwipeDirection.Right))
        {
            MoveOnX(-jumpingDistance);
        }
    }

    public void MoveOnX(float distance)
    {
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }
}
