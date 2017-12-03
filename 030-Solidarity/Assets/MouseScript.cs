using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour {

     private static Vector3 cursorWorldPosOnNCP {
         get {
             return Camera.main.ScreenToWorldPoint(
                 new Vector3(Input.mousePosition.x, 
                 Input.mousePosition.y, 
                 Camera.main.transform.position.y - Camera.main.nearClipPlane));
         }
     }

	private static Vector3 cameraToCursor {
         get {
             return cursorWorldPosOnNCP - Camera.main.transform.position;
         }
     }
 
     private Vector3 cursorOnTransform {
         get {
             Vector3 camToTrans = transform.position - Camera.main.transform.position;
             return Camera.main.transform.position + 
                 cameraToCursor * 
                 (Vector3.Dot(Camera.main.transform.forward, camToTrans) / Vector3.Dot(Camera.main.transform.forward, cameraToCursor));
         }
     }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				Vector3 point = hit.point;
				point.y = 0f;
				transform.position = point;

				NavigateScript[] navigators = FindObjectsOfType<NavigateScript>();
				foreach (NavigateScript navigator in navigators) {
					navigator.SetGoal(transform);
				}
			}
		}	
	}
}
