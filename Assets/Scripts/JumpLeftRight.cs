using UnityEngine;
using System.Collections;

public class JumpLeftRight : MonoBehaviour {

    public bool useKeyboard = true;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Keyboard Controls
        if (useKeyboard)
        {
            if (Input.GetKeyDown(KeyCode.Y))
                JumpLeft();
            else if (Input.GetKeyDown(KeyCode.X))
                JumpRight();
        }
        // Smartphone Controls
        else
        {
            SwipeJump();
        }
    }

    void JumpLeft()
    {
        anim.SetTrigger("JumpLeft");
    }
    
    void JumpRight()
    {
        anim.SetTrigger("JumpRight");
    }

    public void SwipeJump()
    {
        if (Swipe.Instance.IsSwiping(SwipeDirection.Left))
        {
            JumpLeft();
        }
        if (Swipe.Instance.IsSwiping(SwipeDirection.Right))
        {
            JumpRight();
        }
    }
}

