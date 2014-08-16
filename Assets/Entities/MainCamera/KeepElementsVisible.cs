using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class KeepElementsVisible : MonoBehaviour {

		public GameObject[] elements;
		public float nearlimit=4;
		public float farlimit=100;
		public float speed=3;
		public bool moveAlongXAxis = false;
		public bool moveAlongYAxis = true;
		public bool moveAlongZAxis = false;
		private Data data;
		private GameObject cameraTarget;
		private Transform midpoint;
		private Renderer[] renderers;
		private Transform[] transforms;

		// Use this for initialization
		void Start () {
			data = (Data) GetComponent<Data>();
			cameraTarget = new GameObject ();
			midpoint = cameraTarget.transform;
			midpoint.name = "Camera Target for Elements Midpoint";
			data.target = midpoint;
			Reinitialize (true);
		}
		
		// Update is called once per frame
		void Update () {
			moveMidpoint ();
			var currentPosition = data.position.position;
			if (elementsVisible () && allElementsInRange(currentPosition, true)) {
				currentPosition = Vector3.MoveTowards(currentPosition,midpoint.position,speed);
			}
			if (!elementsVisible () && allElementsInRange(currentPosition, false)) {
				currentPosition = Vector3.MoveTowards(currentPosition,midpoint.position,-speed);
			}
			currentPosition = new Vector3 (moveAlongXAxis ? currentPosition.x : data.position.position.x, moveAlongYAxis ? currentPosition.y : data.position.position.y, moveAlongZAxis ? currentPosition.z : data.position.position.z);
			if (data.position == transform) {
				data.position.position = Vector3.Lerp(data.position.position, currentPosition, speed * Time.deltaTime);
			} else {
				data.position.position = currentPosition;
			}
		}

		public void Reinitialize(bool snap = false) {
			renderers = new Renderer[elements.Length];
			transforms = new Transform[elements.Length];
			for (var i = 0; i<elements.Length; i++) {
				if (elements[i] != null) {
					renderers[i] = elements[i].renderer;
					transforms[i] = elements[i].transform;
				}
			}
			moveMidpoint (snap);
		}

		void moveMidpoint(bool instant = false) {
			Vector3 position = new Vector3 (0, 0, 0);
			foreach (var current in transforms) {
				if (current != null)
					position += current.position;
			}
			position = position / transforms.Length;
			if (instant) {
				midpoint.position = position;
			} else {
				var temp = Vector3.Lerp (midpoint.position, position, speed * Time.deltaTime);
				if (!float.IsNaN(temp.x) && !float.IsNaN(temp.y) && !float.IsNaN(temp.z))
					midpoint.position = temp;
			}
		}

		bool elementsVisible() {
			bool allvisible = true;
			foreach (var current in renderers) {
				if (current != null)
					allvisible = allvisible && current.isVisible;
			}
			return allvisible;
		}

		
		
		bool allElementsInRange(Vector3 currentPosition, bool checkNear) {
			bool allInrange = true;
			foreach (var current in transforms) {
				if (current != null)
					if (checkNear) {
						allInrange = allInrange && ((currentPosition - current.position).magnitude > nearlimit);
					} else {
						allInrange = allInrange && ((currentPosition - current.position).magnitude < farlimit);
					}
			}
			return allInrange;
		}
	}
}
