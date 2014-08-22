using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Util {
	public class GameCreator : MonoBehaviour {
		public GameObject blueprint;

		public GameObject LaneBuilder;
		public GameObject[] playerContainer;
		public GameObject[] playerObjects;
		public GameObject Player;

		private GameObject realLane;
		private List<GameObject> createdPlayers;
		
		// Use this for initialization
		void Start () {
			//create ();
		}

		// Use this for initialization
		public void create () {
			realLane = (GameObject) Instantiate (blueprint, LaneBuilder.transform.position, LaneBuilder.transform.rotation);
			realLane.transform.parent = LaneBuilder.transform;
			createdPlayers = new List<GameObject> ();
			for (var i = 0; i < 6; i++) {
				var obj = blueprint.transform.FindChild ("Player"+(i+1).ToString());
				if (obj != null) {
					var realplayer = (GameObject) Instantiate(playerObjects[i],obj.transform.position, obj.transform.rotation);
					realplayer.transform.parent = playerContainer[i].transform;
					realplayer.transform.name = playerObjects[i].name;
					createdPlayers.Add(realplayer);
				}
			}
			Camera.main.transform.position = new Vector3 (0, createdPlayers[0].transform.position.y+30, createdPlayers[0].transform.position.z-10);
			var kv = Camera.main.GetComponent<MainCamera.KeepElementsVisible> ();
			kv.elements = new GameObject[createdPlayers.Count];
			for (int i = 0; i < createdPlayers.Count; i++) {
				kv.elements[i] = createdPlayers[i];
			}
			kv.Reinitialize (true);
			var counter = Player.GetComponent<CustomGUI.CountPlayers> ();
			counter.ReStart ();
			Time.timeScale = 1;
		}

		public void destroy() {
			foreach (GameObject p in createdPlayers) {
				if (p!=null) {
					var remover = p.GetComponent<Player.Remover>();
					if (remover != null) {
						remover.RemoveAndReset();
					}
				}
			}
			Destroy (realLane);
		}
	}
}