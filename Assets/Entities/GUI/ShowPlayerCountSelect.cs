using UnityEngine;
using System.Collections;

namespace Util {
	public class ShowPlayerCountSelect : MonoBehaviour {
		
		public CustomGUI.CountPlayers counter;
		
		private StartEnd starter;

		// Use this for initialization
		void Start () {
			starter = GetComponent<StartEnd> ();
		}
		
		// Update is called once per frame
		void OnGUI () {
			if (!counter.gameRunning && counter.currentPlayerCount != 1) {
				var winningtext = "";
				winningtext += "Number of Players:\n\n";
				winningtext += starter.playerCount.ToString();
				winningtext += "\n\nPlayer 1 is on the left,";
				winningtext += "\nPlayer " + starter.playerCount.ToString() + " is on the right";
				winningtext += "\nPress Space to start";
				GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-70,200,140), winningtext);
			}
		}
	}
}
