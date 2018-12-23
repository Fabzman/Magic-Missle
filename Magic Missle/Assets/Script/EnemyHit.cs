using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {


    public int enemyhealth;
    public ParticleSystem ice;
    public AudioClip death;


    // Use this for initialization
    void Start ()
    {
        //ice = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (Damage)
        //    ice.Play();
        //if (enemyhealth <= 9)
        //{
        //    ice.Play();
        //}
    }

    public void Damage(int damageAmount)
    {
        enemyhealth -= damageAmount;
        //Instantiate(ice.gameObject, transform.position, ice.transform.rotation);

        if (enemyhealth <= 0)
        {
            //gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
