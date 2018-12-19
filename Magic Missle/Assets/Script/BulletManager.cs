using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float bulletSpeed;
    public float lifetime;
    public ParticleSystem ice;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //makes the bullet go whoosh
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(ice.gameObject, transform.position, ice.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mountain")
        {
            Instantiate(ice.gameObject, transform.position, ice.transform.rotation);
            Destroy(gameObject);
        }
    }
}
