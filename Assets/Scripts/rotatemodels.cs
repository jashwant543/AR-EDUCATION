using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatemodels : MonoBehaviour
{
    public GameObject model;
    // public float timetaken = 1.0f;
    public Vector3 target ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(target * Time.deltaTime );
    }
}
