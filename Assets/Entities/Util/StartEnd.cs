using UnityEngine;
using System.Collections;

namespace Util {
	public class StartEnd : MonoBehaviour {

		public GameObject[] starters;
		public CustomGUI.CountPlayers counter;

		public int playerCount;
		private bool isAxisInUse;

		private GameCreator creator;

		// Use this for initialization
		void Start () {
			creator = GetComponent<GameCreator> ();
			playerCount = 2;
			isAxisInUse = false;
		}
		
		// Update is called once per frame
		void Update () {
			if (!counter.gameRunning) {
				if (Input.GetKeyDown (KeyCode.Escape)) {
					Application.Quit ();
				}
				if (counter.currentPlayerCount == 1) {
					if (Input.GetButtonDown("Start")) {
						creator.destroy();
					}
				} else {
					if( Input.GetAxisRaw("Horizontal") != 0)
					{
						if(isAxisInUse == false)
						{
							playerCount += (int)Input.GetAxisRaw("Horizontal");
							playerCount = playerCount % starters.Length;
							if (playerCount==0) {
								playerCount = starters.Length;
							}
							isAxisInUse = true;
						}
					}
					if( Input.GetAxisRaw("Horizontal") == 0)
					{
						isAxisInUse = false;
					}  
					if (Input.GetButtonDown("Start")) {
						creator.blueprint = starters[playerCount-1];
						creator.create();
					}
				}
			} else {
				if (Time.timeScale > 0.1) {
					if (Input.GetKeyDown (KeyCode.Escape)) {
						Time.timeScale = 0;
					}
				} else {
					if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
					}
					
					if (Input.GetButtonDown("Start")) {
						Time.timeScale = 1;
					}
				}
			}
		}
	}
}
