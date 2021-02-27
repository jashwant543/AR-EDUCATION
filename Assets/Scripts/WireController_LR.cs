using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController_LR : MonoBehaviour
{

    private LineRenderer LR;
    private List<Vector3> Points = new List<Vector3>();
    // private Vector3[] Points;
    
    // Start is called before the first frame update

    private  void Awake() 
    {
        LR = GetComponent<LineRenderer>();
    }

    public void DrawLine(List<Vector3> Points)
    {
         LR.positionCount = Points.Count;
         this.Points = Points;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Points.Count; i++)
        {
            LR.SetPosition(i, Points[i]);
        }
    }
}
