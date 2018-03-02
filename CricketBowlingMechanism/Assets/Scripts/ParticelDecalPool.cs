using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticelDecalPool : MonoBehaviour {
	public int maxDecals = 100;
	public float decalSizeMin = 0.5f;
	public float decalSizeMax = 1.5f;

	private int particleDecalDataIndex;
	private ParticleDecalData[] particleData;
	private ParticleSystem.Particle[] particles;
	private ParticleSystem decalParticleSystem;


	// Use this for initialization
	void Start () {
		decalParticleSystem = GetComponent<ParticleSystem>();
		particles = new ParticleSystem.Particle[maxDecals]; 
		particleData = new ParticleDecalData[maxDecals];

		for (int i = 0; i < maxDecals; i++) {
			particleData[i] = new ParticleDecalData();
		}
	}

	public void ParticleHit(Collision particleCollisionEvent, Color splatColor){
		setParticleData(particleCollisionEvent, splatColor);
		DisplayParticles();
	}


	// records collision position, rotation, size and colour
	void setParticleData(Collision col, Color splatColor){
		if (particleDecalDataIndex >= maxDecals) {
			particleDecalDataIndex = 0;
		}

		// so here's the ""fun"" part
		// The only reason I'm having to write any of this code at all is that Unity doesn't come with a decals system
		// So you need to write your own
		// Already fun, right? It gets better
		// The tutorial on the Unity website that this code is all from took ParticleCollisionEvents as the spawnpoint for the decal
		// While this is purportedly because the code was written for a paintgun example,
		// I suspect the entire example was built that way because it's a lot easier to use ParticleCollisionEvents..
		// ...than Collisions.
		// What follows is the line to store position based off of a PCE:
//		particleData[particleDecalDataIndex].position = particleCollisionEvent.intersection;

		// Nice and straightforward. Now let's the same line but with Collision:
		particleData[particleDecalDataIndex].position = col.contacts[0].point;
		// Not much more cryptic
		// But just different enough to make me slightly annoyed.


		Vector3 particleRotationEuler = Quaternion.LookRotation (col.contacts[0].normal).eulerAngles;
		particleRotationEuler.z = Random.Range (0, 360);
		particleData[particleDecalDataIndex].rotation = particleRotationEuler;
		particleData[particleDecalDataIndex].size = Random.Range (decalSizeMin, decalSizeMax);
		particleData[particleDecalDataIndex].color = splatColor;

		particleDecalDataIndex++;
	}

	void DisplayParticles(){
		for (int i = 0; i < particleData.Length; i++) {
			particles[i].position = particleData [i].position;
			particles[i].rotation3D = particleData [i].rotation;
			particles[i].startSize = particleData [i].size;
			particles[i].startColor = particleData [i].color;
		}

		decalParticleSystem.SetParticles(particles, particles.Length);
	}

}
