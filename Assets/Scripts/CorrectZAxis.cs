using UnityEngine;
using System.Collections;

public class CorrectZAxis : MonoBehaviour {

    public float targetZ = 0.4f;
    public float speed = 10f;

    private Transform trans;

    void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        // correct only when...
        if (trans.position.z > targetZ)
        {
            float x = trans.position.x;
            float y = trans.position.y;
            float z = Mathf.Lerp(trans.position.z, targetZ, speed * Time.deltaTime);
            trans.position = new Vector3(x, y, z);
        }
    }
}
