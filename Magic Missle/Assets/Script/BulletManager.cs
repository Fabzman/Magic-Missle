using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float bulletSpeed;
    public float lifetime;
    public ParticleSystem ice;
    public GameObject magicWall;
    public AudioClip crack;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifetime);
        magicWall = GameObject.FindGameObjectWithTag("MagicWall");
    }

    // Update is called once per frame
    void Update()
    {
        //makes the bullet go whoosh
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        //AudioSource.PlayClipAtPoint(shot, Camera.main.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(ice.gameObject, transform.position, ice.transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Crystal")
        {
            magicWall.SetActive(false);
            Instantiate(ice.gameObject, transform.position, ice.transform.rotation);
            AudioSource.PlayClipAtPoint(crack, Camera.main.transform.position);
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
