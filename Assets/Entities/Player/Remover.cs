using UnityEngine;
using System.Collections;
using System;

namespace Player {
	public class Remover : MonoBehaviour {

		
		public void RemoveAndReset() {
			var keepElements = Camera.main.gameObject.GetComponent<MainCamera.KeepElementsVisible> ();
			//	Debug.Log(keepElements);
			GameObject[] dest = new GameObject[keepElements.elements.Length -1];
			//	Debug.Log(dest);
			var index = Array.IndexOf (keepElements.elements, gameObject);
			
			//	Debug.Log(index);
			if (index > 0)
				Array.Copy (keepElements.elements,0,dest,0,index);
			if (index > 0 && index < keepElements.elements.Length - 1)
				Array.Copy (keepElements.elements,index +1, dest, index, keepElements.elements.Length - index - 1);
			keepElements.elements = dest;
			//	Debug.Log("Reinitialize");
			keepElements.Reinitialize (false);
			//		Debug.Log("Destroy");
			Destroy (gameObject);
		}
	}
}
