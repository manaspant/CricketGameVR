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

	// Use this for initialization
	void Start () {
        throwForce = 10.0f;
        
	}

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ballTexture = (Texture2D)Resources.Load("cricket-ball-texture-flat-background-regular-red-leather-pattern-52560591.jpg");
           
            ground = GameObject.Find("Plane");

            cricketBall.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
            cricketBall.transform.position = new Vector3(1f, 4f, -4f);

            GameObject this_cricket_ball = Instantiate(cricketBall);

            //ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //cricketBall.AddComponent<Rigidbody>();
            //bowler = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //bowler.transform.position = new Vector3(0f, 3f, 7f);

            PhysicMaterial material = new PhysicMaterial();
            PhysicMaterial material1 = new PhysicMaterial();

            material1.dynamicFriction = 1;
            material.bounciness = 1;
            material1.bounciness = 0.5F;

            Pcoll = ground.GetComponent<MeshCollider>();
            Pcoll.material = material1;

            coll = this_cricket_ball.GetComponent<SphereCollider>();
            coll.material = material;

            rb = this_cricket_ball.GetComponent<Rigidbody>();
            rb.angularDrag = 1F;

            //ball.GetComponent<Renderer>().material.mainTexture = ballTexture;
            this_cricket_ball.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
            this_cricket_ball.GetComponent<Rigidbody>().useGravity = true;

            //if (rb.velocity.magnitude < 0.5)
            //{
            //    Destroy(ball);

            //}

        }

        if(Input.GetMouseButtonDown(1)){
            // destroy all cricket balls on screen
            // find them using GameObject.FindWithTag
            //var sceneObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("ball"));
            GameObject[] all_balls = GameObject.FindGameObjectsWithTag("ball");

            foreach (GameObject x in all_balls ){
                Destroy(x);
                
            }
        }
    }

    // Update is called once per frame
    void Update () {
        	
	}
}