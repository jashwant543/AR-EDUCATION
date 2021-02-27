using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScriptforLabel : MonoBehaviour
{
    // Start is called before the first frame update
    public bool RotationX,RotationY, RotationZ;

    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RotationX)
        {
          transform.Rotate (Speed, 0f,0f);
        }
        if (RotationY)
        {
            transform.Rotate(0f,Speed,0f);
        }
        if (RotationZ)
        {
            transform.Rotate(0f,0f,Speed);
        }
    }
}
