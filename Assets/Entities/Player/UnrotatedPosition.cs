using UnityEngine;
using System.Collections;

namespace Player {
	public class UnrotatedPosition : MonoBehaviour {
		public Transform player;

		// Update is called once per frame
		void Update () {
			if (player != null)
				transform.position = player.position;
		}
	}
}
