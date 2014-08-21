using UnityEngine;
using System.Collections;

namespace CustomGUI {
	public class Winner : MonoBehaviour {
		
		private CountPlayers counter;
		
		// Use this for initialization
		void Start () {
			counter = GetComponent<CountPlayers>();
		}
		
		// Update is called once per frame
		void OnGUI () {
			if (counter.currentPlayerCount == 1) {
				var winningtext = "";
				winningtext += counter.ranking[0].name + " WON!";
				winningtext += "\n\nCurrent speed: " + counter.ranking[0].rigidbody.velocity.magnitude.ToString("F3");
				winningtext += "\nTravelled distance: " + counter.ranking[0].position.magnitude.ToString("F3");
				winningtext += "\nDropped: " + counter.ranking[0].position.y.ToString("F3");
				GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-100,200,200), winningtext);
				Time.timeScale = 0;
			}
		}
	}
}