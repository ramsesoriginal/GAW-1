using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class FocusTarget : MonoBehaviour {
		
		public Vector3 Target = new Vector3(0,0,0);
		
		private Data data;

		void Start () {
			data = (Data) GetComponent<Data>();
		}

		void Update () {
			if (data!=null)
				Target = data.target.position;
			transform.LookAt (Target);
		}
	}
}