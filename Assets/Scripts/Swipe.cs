using UnityEngine;
using System.Collections;

public enum SwipeDirection
{
    None = 0,
    Left = 1,
    Right = 2,
}

public class Swipe : MonoBehaviour {

    private Vector3 touchPosition;        //erster berührungspunkt.
    private float swipeResistanceX = 300; //minimaler Aufwand um den Swipe durchzuführen 

    private static Swipe instance;
    public static Swipe Instance{ get { return instance; } }

    public SwipeDirection Direction { set; get;}

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        Direction = SwipeDirection.None;

        //Touch wird über den Mouseinput erkannt
        if(Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX) //Swiped nur wenn die bewegung länger ist als der wiederstand
            {
                //Direction = (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;    
                            
                if(deltaSwipe.x < 0)
                {
                    Direction = SwipeDirection.Right;
                }
                else
                {
                    Direction = SwipeDirection.Left;
                }
            }       
        }
    }

    //Gibt zurück ob gerade geswiped wird
    public bool IsSwiping(SwipeDirection direction)
    {
        return (Direction & direction) == direction;
    }

}
