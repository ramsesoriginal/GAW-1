using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class RotateAround : MonoBehaviour {

		public Vector3 Anchor = new Vector3(0,0,0);
		public float rotateSpeed=30;
		
		private Data data;

		private Transform postition;

		void Start () {
			data = (Data) GetComponent<Data>();
			postition = transform; 
		}

		void Update () {
			if (data != null) {
				postition = data.position;
				postition.RotateAround (Anchor, Vector3.up, data.input.position.x * rotateSpeed * Time.deltaTime);
				postition.RotateAround (Anchor, Vector3.left, data.input.position.y * rotateSpeed * Time.deltaTime);
			}
		}
	}
}
