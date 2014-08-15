using UnityEngine;
using System.Collections;

namespace Lanes {
	public class Next : MonoBehaviour {

		public bool left = false;

		private Next brother;

		private LaneBuilder builder;
		private GameObject child;

		// Use this for initialization
		void Start () {
			builder = (LaneBuilder)GetComponentInParent<LaneBuilder> ();
			child = null;
		}
		
		// Update is called once per frame
		void OnTriggerStay (Collider other) {
			if (other.tag == "Player" ) {
				GenerateNext();
			}
		}

		void GenerateNext() {
			if (child == null) {
				Debug.Log (builder.IsSingle);
				Random.seed = (int)System.DateTime.Now.Ticks;
				GameObject[] arraychoice;
				if (builder.IsSingle)
				{
					arraychoice = builder.SingleLane;
				} else {
					arraychoice = builder.DoubleLane;
				}
				var randumber = Random.Range(0,arraychoice.Length);
				GameObject nextPiece =  arraychoice[randumber];
				child = (GameObject)Instantiate(nextPiece,transform.position, transform.rotation);
				child.transform.parent = transform;
				var nextNexts = (Next[]) child.GetComponentsInChildren<Next>();
				if (nextNexts.Length>1)
				{
					nextNexts [0].brother = nextNexts[1];
					nextNexts [1].brother = nextNexts[0];
					builder.IsSingle = false;
					if (brother != null)
					{
						brother.child = new GameObject();
						child.transform.position = (transform.position + brother.transform.position) / 2;
					}
				} else {
					builder.IsSingle = true;
					if (brother != null)
					{
						brother.child =(GameObject)Instantiate(builder.Ender,brother.transform.position, brother.transform.rotation );
						child.transform.parent =brother.transform;
					}
				}
			}
		}
	}
}