using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralManager : MonoBehaviour {

    public float throwForce;
    //public GameObject ball;
    public GameObject ground;
    public GameObject cricketBall;

    public Collider coll;
    public Collider Pcoll;
    public Rigidbody rb;

    public Material secondMat;

	public float actualForce;
	int ballCounter = 0;

	float bowlerX = 1f;
	float actualBX;


	void Start () {
        throwForce = 2f;
        
	}

		
	public void throwBall(){
		//ballTexture = (Texture2D)Resources.Load("cricket-ball-texture-flat-background-regular-red-leather-pattern-52560591.jpg");

		ground = GameObject.Find("Plane");

		//cricketBall.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);



		GameObject this_cricket_ball = Instantiate(cricketBall);
		ballCounter += 1;

		actualBX = bowlerX +Random.Range (-0.2f, 0.2f);
		this_cricket_ball.transform.position = new Vector3(actualBX, 4f, -4f);


		//ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//cricketBall.AddComponent<Rigidbody>();
		//bowler = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//bowler.transform.position = new Vector3(0f, 3f, 7f);

		// PhysicMaterial material = new PhysicMaterial();
		PhysicMaterial material1 = new PhysicMaterial();

		material1.dynamicFriction = 1;
		// material.bounciness = 1;
		material1.bounciness = 0.5F;

		Pcoll = ground.GetComponent<MeshCollider>();
		Pcoll.material = material1;

		coll = this_cricket_ball.GetComponent<SphereCollider>();
		// coll.material = material;

		rb = this_cricket_ball.GetComponent<Rigidbody>();
		rb.angularDrag = 1F;

		//ball.GetComponent<Renderer>().material.mainTexture = ballTexture;
		actualForce = throwForce + Random.Range(-0.2f, 0.2f);

		if (ballCounter % 3 == 0) {
			throwForce += 0.2f;
		}
		if (actualForce > 2f) {
			actualForce = 2f;
			Debug.Log ("Clamping actual force to " + actualForce);
		}

		this_cricket_ball.GetComponent<Rigidbody>().AddForce(transform.forward * actualForce, ForceMode.Impulse);
	}


	public void destroyBalls(){
		GameObject[] all_balls = GameObject.FindGameObjectsWithTag("ball");

		foreach (GameObject x in all_balls ){
			Destroy(x);

		}
	}
}