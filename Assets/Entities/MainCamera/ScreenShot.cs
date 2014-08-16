using UnityEngine;
using System.Collections;

namespace MainCamera {
	public class ScreenShot : MonoBehaviour {

		private string path;

		void Start () {
			if (!System.IO.Directory.Exists ("Screenshot")) {
				System.IO.Directory.CreateDirectory("Screenshot");
			}
			path = "Screenshot" + System.IO.Path.DirectorySeparatorChar;
		}

		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.J)) {
				Application.CaptureScreenshot(path + "Screenshot"+System.DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")+".png");
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				Application.CaptureScreenshot(path + "Screenshot"+System.DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")+".png",3);
			}
		}
	}
}