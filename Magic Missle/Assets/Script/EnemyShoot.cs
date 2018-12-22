using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    private PlayerStats _player;
    public float shootSpeed;
    public Transform player;
    public int magicDamage = 1;
    public float fireRate = .25f;
    public float magicRange = 50f;
    private float nextFire;
    public EnemyFire shot;
    public Transform magicStart;

    // Use this for initialization
    void Start ()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerStats>();
        player = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, player.position) <= magicRange && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            EnemyFire newBullet = Instantiate(shot, magicStart.position, magicStart.rotation) as EnemyFire;
            Vector3 look = player.position;
            //look.y = newBullet.transform.position.y;
            newBullet.transform.LookAt(look);
        }

    }
}
