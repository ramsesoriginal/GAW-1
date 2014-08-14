using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class FloatingPosition : MonoBehaviour {
		
		public Vector3 TargetPosition = new Vector3(0,0,0);
		public float floatSpeed=1;

		private Data data;

		void Start () {
			data = (Data) GetComponent<Data>();
		}

		void Update () {
			if (data!=null)
				TargetPosition = data.position.position;
			transform.position = Vector3.Lerp (transform.position, TargetPosition, floatSpeed * Time.deltaTime);
		}
	}
}