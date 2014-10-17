using UnityEngine;
using System.Collections;

public class CeilingCollisionIndicator : MonoBehaviour {

	public GameObject objectToFlash;

	void OnCollisionEnter(Collision col) {
		Debug.Log ("ceiling collision: " + col.gameObject);
		StartCoroutine (flash ());
	}

	IEnumerator flash() {
		objectToFlash.renderer.enabled = true;
		// wait n frames
		int n = 3;
		for (int i=0; i<n; i++) {
			yield return 0;
		}
		objectToFlash.renderer.enabled = false;
	}
}
