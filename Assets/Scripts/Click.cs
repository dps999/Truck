using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	public Texture btnTexture;
	// Use this for initialization
	void Start () {
		
		Physics.gravity = new Vector3(0, -10.0F, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void OnGUI() {

        
        if (GUI.Button(new Rect(10, 450, 50, 30), "GO!")){
			GameObject truck = GameObject.FindGameObjectWithTag("Truck");
			truck.GetComponent<TruckScript>().StartMove = true;
			GameObject leftBorder = GameObject.Find("Left");
			leftBorder.renderer.enabled = false;
			leftBorder.collider.enabled = false;
		}
         
        
    }
}
