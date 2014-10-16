using UnityEngine;
using System.Collections;

public class FaceLaser : MonoBehaviour {
	
	public GameObject gunBarrel;
	public GameObject cameraObject;
	private double doorDelayTime = 3.0;
	private double nextFireTime = 0.0;
	private GameObject target;
	//private Texture2D door_green = Resources.Load("door_green_bg") as Texture2D;
	//private Texture2D door_trans = Resources.Load("door_trans_bg") as Texture2D;
	
	//Use this for initilization
	void Start ()
	{
		
	}
	
	//Update is called once per frame
	void Update ()
	{
		Fire();
	}
	
	void jumpLocation()
	{
		Debug.Log ("Weapon.jumpLocation: " + target.name);
		teleport ();
		resetDoorway ();
	}
	void teleport()
	{
		Debug.Log ("Weapon.teleport()");
//		Portal doorway_portal = (Portal) target.GetComponent(typeof(Portal));
//		doorway_portal.teleport();
	}
	void set_visibility(bool vis)
	{
		Color targetColor = target.renderer.material.color;
		if (vis == true) 
		{
			//target.renderer.material.mainTexture=door_green;
			//target.renderer.material.color = new Color (targetColor.r, targetColor.g, targetColor.b, (float)0.5);
			target.renderer.material.color = new Color (0, 120, 11, (float)0.75);
		} else {
			//target.renderer.material.mainTexture=door_trans;
			target.renderer.material.color =new Color(255,255,255, (float)0.0);
		}
	}
	void resetDoorway()
	{
		if (target != null) 
		{
			//print("resetDoorway : "+doorway.name);
			set_visibility(false);
			nextFireTime = 0.0;
		}
	}
	
	void Fire()
	{
		//add reload delay for fire - no button mashing : )
		
		RaycastHit hit;
		
		if (Physics.Raycast(gunBarrel.transform.position, gunBarrel.transform.forward, out hit))
		{
			
			if(hit.collider.tag == "Doorway")
			{
				target = hit.collider.gameObject;
				
				//doorway.renderer.material.color = new Color( 0, 0, 255, 0 );
				
				
				//if not set, show the box and start timer
				if(nextFireTime == 0.0)
				{
					//print("Hit : "+doorway.name);
					nextFireTime = Time.time + doorDelayTime; 
					float alphaDelta = (float)(Time.deltaTime/doorDelayTime);
					set_visibility(true);
				}
				//if it's been long enough, go through the door
				if(Time.time > nextFireTime)
				{
					//cameraObject.transform.position = new Vector3(5, 0, 0);
					jumpLocation();
				}
			}else{
				resetDoorway();}
			
		}else{
			//if not hitting the doorway, hide the doorway and reset timer
			resetDoorway();
			
		}
	}
}