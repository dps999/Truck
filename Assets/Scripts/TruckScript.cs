using UnityEngine;
using System.Collections;

public class TruckScript : MonoBehaviour {
	public bool StartMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate() {
		if(StartMove)
    		rigidbody.AddForce(Vector3.left*10000);
    }

}
