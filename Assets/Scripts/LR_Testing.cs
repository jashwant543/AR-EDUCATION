using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LR_Testing : MonoBehaviour
{
    // Start is called before the first frame update
    public static int size = 0;
    // public static Vector3[] Points = new Vector3[size];
    public static List<Vector3> Points = new List<Vector3>();
    public static Dictionary<Vector3, GameObject> NodeDictionary = new Dictionary<Vector3, GameObject>();
    public static List<GameObject> Nodes = new List<GameObject>(); 
    // private int i = 0;
    
    public static GameObject Node;
    public float grid = 1.0f;
    Vector3 pointPos;
    int NodeIndex = 0 ; 

    [SerializeField] private WireController_LR line;

    void Start()
    {
       Node = Resources.Load<GameObject>("Node");
       NodeIndex = 0; 

    }

    // Update is called once per frame
    void Update()
    {
        pointPos = Camera.main.ScreenToWorldPoint(new Vector3((int)Input.mousePosition.x , (int)Input.mousePosition.y ,10.0f));

            // int x = (int)Math.Round(Math.Round(pointPos.x - transform.position.x  - grid / 5.0f) / grid);
            // int y = (int)Math.Round(Math.Round(pointPos.y - transform.position.y  - grid / 5.0f) / grid);
            // int z = (int)Math.Round(Math.Round(pointPos.z - transform.position.z  - grid / 5.0f) / grid);
            
            // pointPos.x = (float)(x) * grid  + transform.position.x + grid / 5.0f;
            // pointPos.y = (float)(y) * grid  + transform.position.y + grid / 5.0f;
            // pointPos.z = (float)(z) * grid  + transform.position.z + grid / 5.0f;
        
       
      if (ButtonInfo.WireBool)
      {
        
        if (Input.GetMouseButtonDown(0)&& !IsPointerOverUIObject())
        {
            // Instantiate(Point, pointPos, Quaternion.identity);
            // Points.Add(Point.transform.position);
            // line.DrawLine(Points);
            if (!NodeDictionary.ContainsKey(pointPos) )
            {
                
              GameObject TempNode = Instantiate(Node, pointPos, Quaternion.identity);
              TempNode.name = ("Node " + NodeIndex);
              NodeIndex ++;
              // NodeDictionary[TempNode.transform.position] = TempNode.transform.position;
              // Points.Add(NodeDictionary[TempNode.transform.position]);
              NodeDictionary.Add(TempNode.transform.position , Node);
              // Nodes.Add(TempNode);
              Points.Add(TempNode.transform.position);
              line.DrawLine(Points);
              // for (int i = 0; i < Points.Count; i++)
              // {
              //     Debug.Log(Points[i]);
              //     // Debug.Log(NodeDictionary[TempNode.transform.position]);
              // }
              
            }

            else
            {
              Points.Add(pointPos);
              line.DrawLine(Points);
            }
            
        }      
      }

      // if (NodeDictionary[pointPos].transform.hasChanged)
      // {
      //   Debug.Log(("Yes I'm Chala"));
      // }
    }

    public static bool IsPointerOverUIObject()
    {
        Debug.Log("IsPointerOverUIObject");
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}