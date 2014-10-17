using UnityEngine;
using System.Collections;

public class ImageTargetCoordinates : MonoBehaviour {

	public Camera fromCamera = null;
	public GameObject objectToMove = null;
	private ImageTargetBehaviour mImageTargetBehaviour = null;

	private static float targetRange_xMin = 0;
	private static float targetRange_xMax = 500;
	private static float targetRange_x = targetRange_xMax - targetRange_xMin;
	private static float targetRange_zMin = 0;
	private static float targetRange_zMax = 350;
	private static float targetRange_z = targetRange_zMax - targetRange_zMin;

	private static float paddleRange_xMin = -1.5f;
	private static float paddleRange_xMax = 1.4f;
	private static float paddleRange_x = paddleRange_xMax - paddleRange_xMin;
	private static float paddleRange_zMin = -1.0f;
	private static float paddleRange_zMax = 1.0f;
	private static float paddleRange_z = paddleRange_zMax - paddleRange_zMin;

	// Use this for initialization
	void Start () {
		// We retrieve the ImageTargetBehaviour component
		// Note: This only works if this script is attached to an ImageTarget
		mImageTargetBehaviour = GetComponent<ImageTargetBehaviour>();
		
		if (mImageTargetBehaviour == null)
		{
			Debug.Log ("ImageTargetBehaviour not found ");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (mImageTargetBehaviour == null)
		{
			Debug.Log ("ImageTargetBehaviour not found");
			return;
		}

		Vector2 targetSize = mImageTargetBehaviour.GetSize();
		float targetAspect = targetSize.x / targetSize.y;
		
		// Note: the target reference plane in Unity is X-Z, 
		// while Y is the normal direction to the target plane
		Vector3 pointOnTarget = new Vector3(-0.5f, 0, -0.5f/targetAspect); 
		// Vector3 pointOnTarget = new Vector3(0.4f, 0, -0.1f); 

		// We convert the local point to world coordinates
		Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);

		if(fromCamera != null) {
			// We project the world coordinates to screen coords (pixels)
			Vector3 screenPoint = fromCamera.WorldToScreenPoint(targetPointInWorldRef);

			// Debug.Log ("target point in screen coords: " + screenPoint.x + ", " + screenPoint.y);
			float targetOffset_x = screenPoint.x - targetRange_xMin;
			float targetOffset_z = screenPoint.y - targetRange_zMin;
			// Debug.Log ("target offset in screen coords: " + targetOffset_x + ", " + targetOffset_z);

			if(targetOffset_x != 0.0 && targetOffset_z != 0.0 && objectToMove != null) {
				// Debug.Log ("scaling x: " + (targetOffset_x / targetRange_x));
				// Debug.Log ("scaling z: " + (targetOffset_z / targetRange_z));

				float finalPosition_x = paddleRange_xMin + paddleRange_x * (targetOffset_x / targetRange_x);
				float finalPosition_z = paddleRange_zMin + paddleRange_z * (targetOffset_z / targetRange_z);
				// Debug.Log ("finalpos in screen coords: " + finalPosition_x + ", " + finalPosition_z);
				objectToMove.transform.position = new Vector3(finalPosition_x, objectToMove.transform.position.y, finalPosition_z);		
			}

		}
	}
}