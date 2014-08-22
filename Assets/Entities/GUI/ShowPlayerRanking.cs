using UnityEngine;
using System.Collections;

namespace CustomGUI {
	public class ShowPlayerRanking : MonoBehaviour {

		private CountPlayers counter;

		// Use this for initialization
		void Start () {
			counter = GetComponent<CountPlayers>();
		}
		
		// Update is called once per frame
		void OnGUI () {
			if (counter.gameRunning) {
				string playerList = "RANKING:\n\n";
				foreach (var player in counter.ranking) {
						if (player!= null)
							playerList += player.name + " (" + player.rigidbody.velocity.magnitude.ToString ("F2") + ")\n";
				}
				GUI.Box (new Rect (10, 10, 200, 200), playerList);
			}
		}
	}
}