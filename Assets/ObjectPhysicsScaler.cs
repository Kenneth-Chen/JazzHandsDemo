using UnityEngine;
using System.Collections;

public class ObjectPhysicsScaler : MonoBehaviour {

	private static float y_min = -18;
	private static float y_max = -4;
	private static float boundsBuffer = 1;
	private static float y_range = y_max - y_min;
	private static float scale_min = 0.5f;
	private static float scale_max = 2.0f;
	private static float scale_range = scale_max - scale_min;
	private Vector3 initScale;

	void Start () {
		initScale = transform.localScale;
		Rigidbody rb = this.GetComponent<Rigidbody>();
		rb.AddForce (8 * Vector3.down, ForceMode.VelocityChange);
	}

	void Update () {
		float y_pct = ((transform.position.y - y_min) / y_range);
		float scalingFactor = scale_min + (y_pct) * scale_range;
		transform.localScale = new Vector3 (scalingFactor * initScale.x, scalingFactor * initScale.y, scalingFactor * initScale.z); 

		// make sure objects stay in bounds
//		if (transform.position.y < y_min - boundsBuffer) {
//			transform.localPosition = new Vector3(transform.position.x, y_min + boundsBuffer, transform.position.z);
//		}
//		if (transform.position.y > y_max + boundsBuffer) {
//			transform.localPosition = new Vector3(transform.position.x, y_max - boundsBuffer, transform.position.z);
//		}

	}
}
