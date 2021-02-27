using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMouseDragging;
    private Vector3 screenPosition, offset;
    private GameObject target;
    public float grid = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                isMouseDragging = true;
                Debug.Log("our target position :" + target.transform.position);
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

        int x = (int)Math.Round(Math.Round(currentPosition.x - transform.position.x - grid / 1.0f) / grid);
        int y = (int)Math.Round(Math.Round(currentPosition.y - transform.position.y - grid / 1.0f) / grid);
        int z = (int)Math.Round(Math.Round(currentPosition.z - transform.position.z - grid / 1.0f) / grid);

        currentPosition.x = (float)(x) * grid + transform.position.x + grid / 1.0f;
        currentPosition.y = (float)(y) * grid + transform.position.y + grid / 1.0f;
        currentPosition.z = (float)(z) * grid + transform.position.z + grid / 1.0f;

        if (isMouseDragging)
        {
            
            //It will update target gameobject's current postion.
            target.transform.position = currentPosition;
        }
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
