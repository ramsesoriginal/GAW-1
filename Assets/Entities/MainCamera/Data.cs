using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class Data : MonoBehaviour {
		
		public Transform position;
		public Transform target;
		public Transform input;
		
		private bool postionTag;
		private bool targetTag;
		private bool inputTag;

		void Start () {
			checkTags ();
			InitAll ();
		}
		
		void Update () {
			InitAll ();
		}

		void InitAll() {
			if (position == null) {
				initPosition();
			}
			if (target == null) {
				initTarget();
			}
			if (input == null) {
				initInput();
			}
		}

		void checkTags() {
			var tags = UnityEditorInternal.InternalEditorUtility.tags;
			foreach (var tag in tags) {
				if (tag == "CameraPositio")
					postionTag = true;
				if (tag == "CameraTarget")
					targetTag = true;
				if (tag == "CameraInput")
					inputTag = true;
			}
		}

		void initPosition() {
			GameObject tempObject = null;
			if (postionTag) {
				tempObject = GameObject.FindWithTag ("CameraPosition");
			}
			if (tempObject == null) {
				tempObject = gameObject;
			}
			position = tempObject.transform;
		}
		
		void initTarget() {
			GameObject tempObject = null;
			if (targetTag) {
				tempObject = GameObject.FindWithTag ("CameraTarget");
			}
			if (tempObject == null) {
				tempObject = new GameObject();
				if (targetTag) {
					tempObject.tag = "CameraTarget";
				}
				tempObject.transform.name = "Camera Target";
				tempObject.transform.position = new Vector3(0,0,0);
			}
			target = tempObject.transform;
		}

		void initInput() {
			GameObject tempObject = null;
			if (inputTag) {
				tempObject = GameObject.FindWithTag ("CameraInput");
			}
			if (tempObject == null) {
				tempObject = new GameObject();
				if (inputTag) {
					tempObject.tag = "CameraInput";
				}
				tempObject.transform.name = "Camera Input";
				tempObject.transform.position = new Vector3(0,0,0);
			}
			input = tempObject.transform;
		}

	}
}
