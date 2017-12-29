using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour {

    public float weaponRange = 100f;

    public Camera myCam;
    public Vector3 lineOrigin = new Vector3(0, 0, 0);

	void Start () {
        myCam = GetComponentInParent<Camera>();
		
	}
	
	
	/**void Update () {
        Vector3 lineOrigin;
        lineOrigin= myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(lineOrigin, myCam.transform.forward * weaponRange, Color.red);
	}
    */
}
