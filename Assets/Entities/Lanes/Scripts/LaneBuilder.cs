using UnityEngine;
using System.Collections;

namespace Lanes {
	public class LaneBuilder : MonoBehaviour {

		public GameObject[] SingleLane;
		public GameObject[] DoubleLane;
		public GameObject Ender;
		private bool isSingle;

		public bool IsSingle {
			get {
				return isSingle;
			}
			set {
				isSingle = value;
			}
		}

		// Use this for initialization
		void Start () {
			isSingle = true;
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}