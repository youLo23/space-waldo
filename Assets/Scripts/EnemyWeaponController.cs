﻿using UnityEngine;
using System.Collections;

public class EnemyWeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource> ();
        InvokeRepeating ("Fire", delay, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fire() {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
