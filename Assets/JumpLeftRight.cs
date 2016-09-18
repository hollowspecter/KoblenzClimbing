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
            // "swipe left" -> JumpLeft();
            // "swipe right" -> JumpRight();
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
}
