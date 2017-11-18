using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputClick : MonoBehaviour {

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
	
	public Domino domino;
	private Domino selectedDomino;
	private float yAngle = 0;
	// Update is called once per frame
	void Update () {		
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) {
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				if (hit.transform.gameObject.GetComponent<Domino>() == null) {
					Vector3 point = hit.point;
					point.y = 1f;
					Debug.Log(point);
					selectedDomino = Instantiate<Domino>(domino);
					selectedDomino.transform.position = point;
					selectedDomino.transform.eulerAngles = new Vector3(0, yAngle, 0);
				} else {
					selectedDomino = hit.transform.gameObject.GetComponent<Domino>();
				}
			}
		} else if (Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2")) {
			selectedDomino = null;			
		}
		if (Input.GetButtonDown("Fire2")) {
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				selectedDomino = hit.transform.gameObject.GetComponent<Domino>();
				if (selectedDomino != null) {
					yAngle = selectedDomino.transform.eulerAngles.y;
				}
			}
		}

		if (selectedDomino != null) {
			if (Input.GetButton("Fire2")) {
				yAngle += Input.GetAxis("Mouse X") * 5;
				selectedDomino.transform.eulerAngles = new Vector3(0, yAngle, 0);
			} else if (Input.GetButton("Fire1")) {
				Vector3 point = cursorWorldPosOnNCP;
				point.y = 1f;
				selectedDomino.transform.position = point;
			}
		}
	}
}
