using UnityEngine;
using System.Collections;

public class DragNDrop : MonoBehaviour {
	Vector3 screenPoint ;
	Vector3 offset;
	private bool selected;
	private bool rotate;
	float 	_horizontalLimit = 2.5f, _verticalLimit = 2.5f, dragSpeed = 0.1f;
	private float xDeg, yDeg;
	private Quaternion fromRotation;
	private Quaternion toRotation;
	Transform cachedTransform;
	Vector3 startingPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit = new RaycastHit();
 		int fingerCount = 0;
        foreach (Touch touch in Input.touches) {
			int tapCount = Input.touchCount;
			if(tapCount > 1) rotate = true;
			else rotate = false;
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			if (touch.phase == TouchPhase.Began) {

                if (Physics.Raycast(ray, out hit, 100)) {

                    if (hit.collider.gameObject == gameObject) {

                        selected = true;

                    }

                }

            } else if (touch.phase == TouchPhase.Moved) {

                if (selected == true) {


					if(!rotate){
				    	Vector3 curScreenPoint = new Vector3(touch.position.x, touch.position.y, 1);
					    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
				   	    transform.position = new Vector3( curPosition.x, curPosition.y, 1);
					}
					else{
				    	Vector3 curScreenPoint = new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y, 1);
					    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
						xDeg -= curPosition.x;
				        yDeg += curPosition.y;
				        fromRotation = transform.rotation;
				        toRotation = Quaternion.Euler(0,0,xDeg/50);
				        transform.rotation = toRotation;
					}
                    /**

                     * replace the line above with this one to enable full x,y positioning

                     * oT.position = touchPosition;

                     */

                }

            } else if (touch.phase == TouchPhase.Ended) {

                selected = false;

            }			
        }	
	}
	
	
/*	void OnMouseDown()
	{
		Vector3 scanPos = Input.mousePosition;
	    screenPoint = Camera.main.WorldToScreenPoint(scanPos);
	 
	   // offset = scanPos - Camera.main.ScreenToWorldPoint(
	   //    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
	}*/
 
 
	void OnMouseDrag()
	{
	    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
	 
	    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
								xDeg -= curPosition.x;
				        yDeg += curPosition.y;
				        fromRotation = transform.rotation;
				        toRotation = Quaternion.Euler(0,0,xDeg);
				      //  transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime *5);
	//	transform.Rotate(0,0,xDeg/1000);
	    transform.position = new Vector3( curPosition.x, curPosition.y, 1);
	}
}
