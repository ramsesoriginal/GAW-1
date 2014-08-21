using UnityEngine;
using System.Collections;

namespace Lanes {
	public class RemoverFront : MonoBehaviour {

		private Next next;

		// Use this for initialization
		void Start () {
			next = transform.parent.GetComponentInChildren<Next> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (!next.isFront)
				Destroy (gameObject);
		}
	}
}