using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
	private Vector3 desiredPosition;

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

				}
			}
		}
	}
		
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

}