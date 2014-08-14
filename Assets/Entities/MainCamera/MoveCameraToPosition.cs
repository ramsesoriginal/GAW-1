using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class MoveCameraToPosition : MonoBehaviour {

		public Vector3 newPosition;
		public float defaultSpeed = 1;
		public float tolerance = 0.1f;
		public bool move;

		private Data data;
		private float moveSpeed = 1;
		
		void Start () {
			data = (Data) GetComponent<Data>();
			move = false;
		}
		
		// Update is called once per frame
		void Update () {
			if (data != null) {
				if (move) {
					data.position.position = Vector3.Lerp (data.position.position , newPosition, moveSpeed * Time.deltaTime);
					if ((data.position.position-newPosition).magnitude < tolerance)
					{
						data.position.position = newPosition;
						move = false;
					}
				}
			}
		}
		
		public void MoveTo(Vector3 whereTo, float speed) {
			newPosition = whereTo;
			move = true;
			moveSpeed = speed;
		}

		public void MoveTo(Vector3 whereTo) {
			MoveTo(whereTo,defaultSpeed);
		}
		
		public void MoveTo(Transform whereTo, float speed) {
			MoveTo(whereTo.position, speed);
		}
		
		public void MoveTo(Transform whereTo) {
			MoveTo(whereTo.position);
		}
		
		public void MoveTo(GameObject whereTo, float speed) {
			MoveTo(whereTo.transform.position, speed);
		}
		
		public void MoveTo(GameObject whereTo) {
			MoveTo(whereTo.transform.position);
		}
	}
}
