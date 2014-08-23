using UnityEngine;
using System.Collections;

public class Newsticker : MonoBehaviour {

	private string news;

	public CustomGUI.CountPlayers counter;

	public string url = "https://gist.githubusercontent.com/ramsesoriginal/3b467c8e6b7e68bc898d/raw/GAW";

	IEnumerator Start() {
		WWW www = new WWW(url);
		yield return www;
		news = www.text;
	}

	void OnGUI () {
		if (!counter.gameRunning && counter.currentPlayerCount != 1) {
			if (news != null) {
					var cache = GUI.skin.label.wordWrap;
					GUI.skin.label.wordWrap = true;
					GUI.Label (new Rect (10, Screen.height / 2 + 100, Screen.width - 20, Screen.height / 2 - 110), "<b>NEWS:</b>\n\n" + news);
					GUI.skin.label.wordWrap = cache;
			}
		}
	}
}
