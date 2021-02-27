using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instensiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject games;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           int  c = 0;
            Debug.Log("left");
            if(c%2==0)
                Instantiate(games, new Vector3(0f, 0f, 0), Quaternion.identity);

            else
                games.SetActive(false);

            c++;
        }
    }
}
