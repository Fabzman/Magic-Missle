using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public float bulletSpeed;
    public float lifetime;
    public ParticleSystem fire;
    private PlayerStats _player;

    // Use this for initialization
    void Start ()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(fire.gameObject, transform.position, fire.transform.rotation);
            _player.health -= 1;
            Destroy(gameObject);
        }

        if (other.tag != "Enemy")
        {
            Destroy(gameObject);
            //Debug.Log(other.tag);
        }

        if (other.tag == "Walls")
        {
            Destroy(gameObject);
            //Debug.Log(other.tag);
        }
    }
}
