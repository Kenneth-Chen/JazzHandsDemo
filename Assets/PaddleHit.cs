using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaddleHit : MonoBehaviour {
	
	void OnCollisionEnter(Collision col) {
		Debug.Log ("paddle hit: " + col.gameObject);
		Rigidbody rb = this.GetComponent<Rigidbody>();
		// rb.AddForce (1 * Vector3.down, ForceMode.Impulse);
		StartCoroutine (flash ());
	}
	
	IEnumerator flash() {
		Renderer[] renderers = this.GetComponentsInChildren<Renderer> ();
		List<Renderer> renderersToFlash = new List<Renderer> ();
		foreach (Renderer renderer in renderers) {
			if(!renderer.enabled) {
				renderersToFlash.Add(renderer);
			}
			renderer.enabled = true;
		}
		// wait n frames
		int n = 3;
		for (int i=0; i<n; i++) {
			yield return 0;
		}
		foreach (Renderer renderer in renderersToFlash) {
			renderer.enabled = false;
		}
	}
	
}
