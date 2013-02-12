using UnityEngine;
using System.Collections;

public class SelectedObject : MonoBehaviour {
	public GameObject selectedObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    void OnGUI() {

        
        if (GUI.Button(new Rect(10, 450, 50, 30), "GO!")){
			GameObject truck = GameObject.FindGameObjectWithTag("Truck");
			truck.GetComponent<CarController>().accel = -0.05f;
			GameObject leftBorder = GameObject.Find("Left");
			leftBorder.renderer.enabled = false;
			leftBorder.collider.enabled = false;
			GameObject[] luggage = GameObject.FindGameObjectsWithTag("Luggage");
			foreach (GameObject obj in luggage){ 
				obj.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
			}
		}

		if (GUI.Button(new Rect(250, 450, 50, 30), "Rotate")){
			selectedObject.transform.localRotation = Quaternion.Euler(0,0, selectedObject.transform.localEulerAngles.z + 90);
		}
        
    }

}
