using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public GameObject motherCube;

    public List<GameObject> cubeArray = new List<GameObject>();
    public List<GameObject> weapons;

    public float speed = 5.0f;

    public Vector3 direction;

    BoxCollider myCollider;// 
    BoxCollider tempCollider;


    // Use this for initialization
    void Start () {
        myCollider = GetComponent<BoxCollider>();

        cubeArray.Add(motherCube);
        direction = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void FixedUpdate()
    {
        myCollider = GetComponent<BoxCollider>();

        for (int i = 0; i < cubeArray.Count; i++)
        {
           
            tempCollider = cubeArray[i].GetComponentInChildren<BoxCollider>();

            if (tempCollider != null)
            {
                myCollider.bounds.Expand(tempCollider.bounds.size);
            }   
        }
    }
}
