using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class AvoidObstacles : MonoBehaviour {

		public float height = 5.0f;
		public float speed = 2.0f;
		private Data data;

		// Use this for initialization
		void Start () {
			data = (Data) GetComponent<Data>();
		}
		
		// Update is called once per frame
		void Update () {
			var targetPos = new Vector3(data.position.position.x, data.position.position.y, data.position.position.z);
			RaycastHit hit;
			if (Physics.Raycast(targetPos, Vector3.down, out hit)) {
				if (Vector3.Distance(hit.point, targetPos) < height) {
					targetPos.y = Mathf.Lerp(targetPos.y, targetPos.y + height, speed*Time.deltaTime);
				} else {
					targetPos.y = Mathf.Lerp(targetPos.y, hit.point.y + height, speed*Time.deltaTime);
				}
			} else if (Physics.Raycast(targetPos, Vector3.up, out hit)) {
				targetPos.y += height + Vector3.Distance(hit.point, targetPos);
			}
			data.position.position = targetPos;
		}
	}
}