using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    public static float speed = 2f;

    Vector2 pos;
    bool wrongColor;

	// Use this for initialization
	void Start ()
    {
        speed = 2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(speed);
        transform.position +=Vector3.down * speed * Time.deltaTime;
        if(wrongColor)
        {
            transform.position = pos;
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player"||collision.transform.tag=="Cube")
        {
            pos = transform.position;
            //Cube.speed = 0;
            wrongColor = true;
        }
    }
}
