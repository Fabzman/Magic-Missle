﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLaser : MonoBehaviour {

    public int magicDamage = 1;
    public float fireRate = .25f;
    public float magicRange = 50f;
    public float hitForce = 100f;
    public Transform magicEnd;
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource magicAudio;
    private LineRenderer laserLine;
    private float nextFire;
    public BulletManager shot;
    public ParticleSystem iceShot;

    // Use this for initialization
    void Start ()
    {
        laserLine = GetComponent<LineRenderer>();
        magicAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        //if (Input.GetKey("Mouse1") && Time.time > nextFire)

        {
            nextFire = Time.time + fireRate;

            Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, magicEnd.position);

            if (Physics.Raycast(ray, out hit, magicRange, LayerMask.NameToLayer("Arms")))
            {
                laserLine.SetPosition(1, hit.point);
                EnemyHit health = hit.collider.GetComponent<EnemyHit>();
                StartCoroutine(ShotEffect());
                BulletManager newBullet = Instantiate(shot, magicEnd.position, magicEnd.rotation) as BulletManager;
                newBullet.transform.forward = ray.direction;

                if (health != null)
                {
                    health.Damage(magicDamage);
                    //iceShot.Play();
                    //Instantiate(ice.gameObject, transform.position, ice.transform.rotation);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }

            else

            {
                laserLine.SetPosition(1, fpsCam.transform.forward * magicRange);
            }
        }

    }

    private IEnumerator ShotEffect()

    {
        if(magicAudio)
            magicAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
