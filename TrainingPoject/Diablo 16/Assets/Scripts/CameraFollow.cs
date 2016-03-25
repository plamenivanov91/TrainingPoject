using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	public  GameObject player;
	private Vector3 offset;
	private Vector3 desiredPosition;
	public GameObject cubeObj;
	private bool positionedOnDesiredPoint = true;
	Animator playerAnimator;

	void Start ()
	{
		                                                
		offset = transform.position - player.transform.position;
		playerAnimator = player.GetComponent<Animator> ();
	}

	void Update ()
	{
		if (Input.GetMouseButton (1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider != null && !hit.collider.CompareTag ("Player")) {
					player.transform.LookAt (hit.point);
					desiredPosition = hit.point;
					positionedOnDesiredPoint = false;
				}
			}
		}

		if (!positionedOnDesiredPoint) {
			Vector3 dir = desiredPosition - player.transform.position;
			float dist = dir.magnitude;
			if (dist <= .9f) {
				positionedOnDesiredPoint = true;
				playerAnimator.SetBool ("isRunning", false);
			} else {
				playerAnimator.SetBool ("isRunning", true);
				player.transform.Translate (Vector3.forward * .9f);
			}
		}
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}

}   