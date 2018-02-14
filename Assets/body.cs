using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour {

    // Use this for initialization

    public  GameObject next;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void moveTo(Vector3 pos)
    {
        Vector3 old = this.transform.position;
        this.transform.position = pos;//当前坐标变为pos.  
        if (next != null)
        {
            next.GetComponent<body>().moveTo(old);
        }



    }
}
