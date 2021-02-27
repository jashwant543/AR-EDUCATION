using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               
    }


    public void SpawnObjects()
    {
        GameObject ComponentModel = Resources.Load<GameObject>("ComponentModel/Diode");
        for (int i = 0; i < instantiate.ComponentList.Count; i++)
        {
            Instantiate(ComponentModel, instantiate.ComponentPositionList[i], Quaternion.identity);
            Debug.Log(instantiate.ComponentPositionList[i]);
            if (i == (instantiate.ComponentList.Count-1))
            {
                break;
            }
        }
    }

    public void SpawnWire(GameObject WireModel)
    {
        for (int i = 0; i < instantiate.ComponentList.Count; i++)
        {
            Vector3 MidPos = (instantiate.ComponentPositionList[i] + instantiate.ComponentPositionList[i - 1]) / 2.0f;
            // WireModel.transform.
            Instantiate(WireModel, MidPos, Quaternion.identity);
        }
    }
}
