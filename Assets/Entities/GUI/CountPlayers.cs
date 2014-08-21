using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


namespace CustomGUI {
	public class CountPlayers : MonoBehaviour {

		public int playerCount;
		public int currentPlayerCount;
		public Transform[] ranking;

		private List<Transform> players;

		// Use this for initialization
		void Start () {
			currentPlayerCount = countPlayers ();
			playerCount = currentPlayerCount;
		}
		
		// Update is called once per frame
		void Update () {
			currentPlayerCount = countPlayers ();
		}

		int countPlayers() {
			var locomotions = GetComponentsInChildren<Player.Locomotion> ();
			players = new List<Transform>();
			foreach(var l in locomotions) {
				players.Add(l.transform);
			}
			ranking = players.OrderBy (q => -q.position.magnitude).ToArray ();
			return locomotions.Count();
		}
	}
}
