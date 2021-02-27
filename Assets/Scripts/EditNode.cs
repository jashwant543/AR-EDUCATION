using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditNode : MonoBehaviour 
{
    // Start is called before the first frame update

       private float FirstClickTIme , TimeBetweenClicks;
       private bool CoroutineAllowed;
       private int ClickCounter;


    // Start is called before the first frame update
    private bool isMouseDragging;
    private Vector3 screenPosition, offset;
    private GameObject WireRenderer;
    private GameObject target;
    public static Dictionary<Vector3, GameObject> NodeDictionaryTwo = new Dictionary<Vector3, GameObject>();
    public float grid = 1.0f;

    void Start()
    {
        WireRenderer = GameObject.Find("WireRenderer");
        FirstClickTIme = 0.0f;
        TimeBetweenClicks = 0.2f;
        ClickCounter = 0;
        CoroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonInfo.NodeBool)
        { 
          WireRenderer.GetComponent<WireController_LR>().enabled = false;

          
          
         if (Input.GetMouseButtonDown(0))
          {
            ClickCounter +=1;
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                isMouseDragging = true;
                // Debug.Log("our target position :" + target.transform.position);
                //Here we Convert world position to screen position.
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        //tracking mouse position.
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

        //convert screen position to world position with offset changes.
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

        // int x = (int)Math.Round(Math.Round(currentPosition.x - transform.position.x - grid / 5.0f) / grid);
        // int y = (int)Math.Round(Math.Round(currentPosition.y - transform.position.y - grid / 5.0f) / grid);
        // int z = (int)Math.Round(Math.Round(currentPosition.z - transform.position.z - grid / 5.0f) / grid);

        // currentPosition.x = (float)(x) * grid + transform.position.x + grid / 5.0f;
        // currentPosition.y = (float)(y) * grid + transform.position.y + grid / 5.0f;
        // currentPosition.z = (float)(z) * grid + transform.position.z + grid / 5.0f;

        if (isMouseDragging)
        {
            
            //It will update target gameobject's current postion.
            target.transform.position = currentPosition;   //// node ki position change

            int currentIndex = int.Parse(target.name.Substring(target.name.Length - 1));
            // Debug.Log(currentIndex);
            WireRenderer.GetComponent<LineRenderer>().SetPosition(currentIndex , target.transform.position);
            LR_Testing.Points[currentIndex] =  target.transform.position;



            // for (int i = 0 ; i <= LR_Testing.Points.Count; i++)
            // {
            //     if (target.name.Last() == LR_Testing.Points[i])
            //     {
            //         Debug.Log("Yes it's true");
            //         target.transform.position = currentPosition;
            //         LR_Testing.Points[i] = target.transform.position;
            //     }
            // }
        }

        if (ClickCounter == 1 && CoroutineAllowed )
        {
            FirstClickTIme = Time.time;
            StartCoroutine(DoubleClickDetection());
        }

    }
}


    private IEnumerator DoubleClickDetection()
    {
        CoroutineAllowed = false;
       
        while (Time.time < FirstClickTIme + TimeBetweenClicks)
        {
            // RaycastHit hitInfo;
            // target = ReturnClickedObject(out hitInfo);
            if (ClickCounter == 2 && target != null)
            {
                Debug.Log("Double Click");
                // Debug.Log(target.transform.name);
                // Destroy(target);
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        ClickCounter = 0;
        FirstClickTIme = 0f;
        CoroutineAllowed = true;
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject targetObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            targetObject = hit.collider.gameObject;
        }
        return targetObject;
    }

    
}
