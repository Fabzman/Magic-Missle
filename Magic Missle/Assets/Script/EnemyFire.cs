using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFire : MonoBehaviour {

    public float bulletSpeed;
    public float lifetime;
    public ParticleSystem fire;
    private PlayerStats _player;
    public AudioClip death;

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

        if (_player.health <= 0)
        {
            AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
            SceneManager.LoadScene("Wizard Tower");
        }

        //if (other.tag != "Enemy")
        //{
        //    Destroy(gameObject);
        //    //Debug.Log(other.tag);
        //}

        if (other.tag == "Walls")
        {
            Destroy(gameObject);
            //Debug.Log(other.tag);
        }
    }
}
