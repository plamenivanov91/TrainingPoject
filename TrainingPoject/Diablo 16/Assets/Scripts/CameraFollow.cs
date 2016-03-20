using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
	private Vector3 desiredPosition;
	public GameObject cubeObj;
	private bool moveTheFaggot = false;

	void Start () {
		
        offset = transform.position - player.transform.position;

	}

	void Update(){
		if (Input.GetMouseButton(1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider != null && !hit.collider.CompareTag("Player")) {
					player.transform.LookAt (hit.point);
					desiredPosition = hit.point;
					moveTheFaggot = true;
				}
			}
		}
	}

	void FixedUpdate(){
		
		if (moveTheFaggot) {
			if (player.transform.position == desiredPosition) {
				Debug.Log ("Arrived at point");
				moveTheFaggot = false;
			} else {
				Vector3 kovra = new Vector3 (desiredPosition.x - player.transform.position.x, 0f, desiredPosition.z - player.transform.position.z);
				player.transform.position += (kovra * 0.1f);
			}
		}

	}

	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

}