using UnityEngine;
using System.Collections;

namespace Lanes {
	public class Limiter : MonoBehaviour {

		// Update is called once per frame
		void OnTriggerStay (Collider other) {
			if (other.tag == "Player" ) {
				var remover = other.gameObject.GetComponent<Player.Remover>();
				remover.RemoveAndReset();
			}
		}
	}
}
