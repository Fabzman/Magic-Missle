using UnityEngine;
using System.Collections;

public class ChangeWeapons : MonoBehaviour 
{
    //Declare WeaponsArray of GameObjects + set in Unity
    public GameObject[] weaponsSwap;

    void Start () 
    {
        Cursor.visible = false;//hide cursor

        //set weapon to default
    }

    void Update () 
    {
        //if Input "1"
        if (Input.GetButtonDown ("1"))
        //call function(0);
        {
            
        }
        //if Input "2"
        if (Input.GetButtonDown("2"))
        //call function(1);
        {

        }
        //if Input "3"
        if (Input.GetButtonDown("3"))
        //call function(2);
        {

        }
        //if Input "4"
        if (Input.GetButtonDown("4"))
        //call function(3);
        {

        }
    }

    //function(passedValue)
        //for (1 to WeaponsArray.Length)
            //if (loopValue == passedValue)
                //WeaponsArray [current element].SetActive(true)
            //else 
                //WeaponsArray [current element].SetActive(false)
}
