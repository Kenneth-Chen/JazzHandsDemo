using UnityEngine;
using System.Collections;

public class FloorCollisionDetector : MonoBehaviour {
	
	void OnCollisionEnter(Collision col) {
		Debug.Log ("floor collision: " + col.gameObject);
		Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
		float randomForceStrengthRange = 1.5f;
		float bounceStrength = 1.3f;
		Vector3 returnForce = new Vector3 (-randomForceStrengthRange/2 + randomForceStrengthRange * Random.value, bounceStrength, -randomForceStrengthRange/2 + randomForceStrengthRange * Random.value);
		rb.AddForce (returnForce, ForceMode.VelocityChange);
	}
}
