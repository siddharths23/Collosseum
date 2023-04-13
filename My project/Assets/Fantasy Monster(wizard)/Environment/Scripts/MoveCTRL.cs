using UnityEngine;
using System.Collections;

public class MoveCTRL : MonoBehaviour {

	private float move = 20;
	private bool stop = false;	
	private float blend;
	private float delay = 0;
	public float AddRunSpeed = 1;
	public float AddWalkSpeed = 1;
	private bool hasAniComp = false;

	// Use this for initialization
	void Start () 
	{
	
		if ( null != GetComponent<Animation>() )
		{
			hasAniComp = true;
		}

	}

	void Move ()
	{ 
		float speed =0.0f;
		float add =0.0f;

		if ( hasAniComp == true )
		{	
			if ( Input.GetKey(KeyCode.W) )
			{  	
				move *= 1.015F;

				if ( move>250 && CheckAniClip( "move_forward_fast" )==true )
				{
					{
						GetComponent<Animation>().CrossFade("move_forward_fast");
						add = 20*AddRunSpeed;
					}
				}
				else
				{
					GetComponent<Animation>().Play("move_forward");
					add = 5*AddWalkSpeed;
				}

				speed = Time.deltaTime*add;

				transform.Translate( 0,0,speed );
			}


			if ( Input.GetKeyUp(KeyCode.W))
			{
				if ( GetComponent<Animation>().IsPlaying("move_forward"))
				{	GetComponent<Animation>().CrossFade("idle_normal",0.3f); }
				if ( GetComponent<Animation>().IsPlaying("move_forward_fast"))
				{	
					GetComponent<Animation>().CrossFade("idle_normal",0.5f);
					stop = true;
				}	
				move = 20;
			}

			if (stop == true)
			{	
				float max = Time.deltaTime*20*AddRunSpeed;
				blend = Mathf.Lerp(max,0,delay);

				if ( blend > 0 )
				{	
					transform.Translate( 0,0,blend );
					delay += 0.025f; 
				}	
				else 
				{	
					stop = false;
					delay = 0.0f;
				}
			}


			if ( Input.GetKey(KeyCode.LeftArrow))
			{
				//				add = 5*AddWalkSpeed;
				GetComponent<Animation>().Play("move_left");
				speed = Time.deltaTime*5*AddWalkSpeed;
				transform.Translate( -speed,0,0 );
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				//				add = 5*AddWalkSpeed;
				GetComponent<Animation>().Play("move_right");
				speed = Time.deltaTime*5*AddWalkSpeed;
				transform.Translate( speed,0,0 );
			}

			if (Input.GetKey(KeyCode.S))
			{
				//				add = 5*AddWalkSpeed;
				GetComponent<Animation>().Play("move_backward");
				speed = Time.deltaTime*5*AddWalkSpeed;
				transform.Translate( 0,0,-speed );
			}

		}
		else
		{
			if ( Input.GetKey(KeyCode.W) )
			{  	
				add = 5*AddWalkSpeed;
				speed = Time.deltaTime*add;
				transform.Translate( 0,0,speed );
			}

			if ( Input.GetKey(KeyCode.RightArrow))
			{
				//				add = 5*AddWalkSpeed;
				speed = Time.deltaTime*5*AddWalkSpeed;
				transform.Translate( speed,0,0 );
			}

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				//				add = 5*AddWalkSpeed;
				speed = Time.deltaTime*5*AddWalkSpeed;
				transform.Translate( -speed,0,0 );
			}

			if (Input.GetKey(KeyCode.S))
			{
				//				add = 5*AddWalkSpeed;
				speed = Time.deltaTime*5*AddWalkSpeed;
				transform.Translate( 0,0,-speed );
			}
		}
	}

	bool CheckAniClip ( string clipname )
	{	
		if( this.GetComponent<Animation>().GetClip(clipname) == null ) 
			return false;
		else if ( this.GetComponent<Animation>().GetClip(clipname) != null ) 
			return true;

		return false;
	}

	// Update is called once per frame
	void Update () 
	{
	
		Move();

		if ( hasAniComp == true )
		{	
			if (Input.GetKey(KeyCode.Delete))
			{	
				if ( CheckAniClip( "dead" ) == false ) return;

				GetComponent<Animation>().CrossFade("dead",0.2f);
				//					animation.CrossFadeQueued("idle_normal");
			} 

			if (Input.GetKey(KeyCode.C))
			{	
				if ( CheckAniClip( "damage_003" ) == false ) return;

				GetComponent<Animation>().CrossFade("damage_003",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			} 

			if (Input.GetKey(KeyCode.Alpha3))
			{	
				if ( CheckAniClip( "attack_middle_001" ) == false ) return;

				GetComponent<Animation>().CrossFade("attack_middle_001",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			} 

			if (Input.GetKey(KeyCode.Alpha1))
			{	
				if ( CheckAniClip( "attack_middle_002" ) == false ) return;

				GetComponent<Animation>().CrossFade("attack_middle_002",0.3f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			} 

			if (Input.GetKey(KeyCode.Alpha4))
			{	
				if ( CheckAniClip( "attack_short_001" ) == false ) return;

				GetComponent<Animation>().CrossFade("attack_short_001",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			}

			if (Input.GetKey(KeyCode.Alpha0))
			{	
				if ( CheckAniClip( "attack_short_002" ) == false ) return;

				GetComponent<Animation>().CrossFade("attack_short_002",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			}

			if (Input.GetKey(KeyCode.Alpha2))
			{	
				if ( CheckAniClip( "attack_long_001" ) == false ) return;

				GetComponent<Animation>().CrossFade("attack_long_001",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			}

			if (Input.GetKey(KeyCode.Z))
			{	
				if ( CheckAniClip( "damage_001" ) == false ) return;

				GetComponent<Animation>().CrossFade("damage_001",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			}

			if (Input.GetKey(KeyCode.Alpha5))
			{	
				if ( CheckAniClip( "attack_buff_001" ) == false ) return;

				GetComponent<Animation>().CrossFade("attack_buff_001",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");			
			}

			if (Input.GetKey(KeyCode.X))
			{	
				if ( CheckAniClip( "damage_002" ) == false ) return;

				GetComponent<Animation>().CrossFade("damage_002",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");			
			}			

			if (Input.GetKey(KeyCode.Home))
			{	
				if ( CheckAniClip( "idle_normal" ) == false ) return;

				GetComponent<Animation>().CrossFade("idle_normal",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_normal");			
			}			

			if (Input.GetKey(KeyCode.F))
			{	
				if ( CheckAniClip( "idle_combat" ) == false ) return;

				GetComponent<Animation>().CrossFade("idle_combat",0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_normal");			
			}			
		}

		if ( Input.GetKey(KeyCode.A))
		{
			transform.Rotate( 0,Time.deltaTime*-100,0);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0,Time.deltaTime*100,0);
		}

	}
}
