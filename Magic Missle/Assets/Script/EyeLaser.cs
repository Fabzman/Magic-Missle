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
    public AudioClip magic;
    private LineRenderer laserLine;
    public PlayerStats player;
    private float nextFire;
    public BulletManager shot;
    //public ParticleSystem iceShot;

    // Use this for initialization
    void Start ()
    {
        //laserLine = GetComponent<LineRenderer>();
        //magicAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
        player = GetComponentInParent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        if (Input.GetButton("Fire1") && Time.time > nextFire && player.ammo > 0)
        //if (Input.GetKey("Mouse1") && Time.time > nextFire)

        {
            nextFire = Time.time + fireRate;

            Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            //laserLine.SetPosition(0, magicEnd.position);

            if (Physics.Raycast(ray, out hit, magicRange, LayerMask.NameToLayer("Arms")))
            {
                //laserLine.SetPosition(1, hit.point);
                EnemyHit health = hit.collider.GetComponent<EnemyHit>();
                StartCoroutine(ShotEffect());
                BulletManager newBullet = Instantiate(shot, magicEnd.position, magicEnd.rotation) as BulletManager;
                player.ammo -= 1;
                newBullet.transform.forward = ray.direction;

                if (health != null)
                {
                    health.Damage(magicDamage);
                    AudioSource.PlayClipAtPoint(magic, Camera.main.transform.position);
                    //player.ammo -= 1;
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
                //laserLine.SetPosition(1, fpsCam.transform.forward * magicRange);
            }
        }

    }

    private IEnumerator ShotEffect()

    {
        //if (magicAudio)
        //    magicAudio.Play();
        //laserLine.enabled = true;
        yield return shotDuration;
        //laserLine.enabled = false;
    }
}
