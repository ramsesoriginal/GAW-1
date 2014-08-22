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

		public bool gameRunning {
			get {
				return currentPlayerCount>1;
			}
		}

		// Use this for initialization
		void Start () {
			ReStart ();
		}
		
		// Use this for initialization
		public void ReStart () {
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
