using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanner : MonoBehaviour {

    public Transform[] spawnpoints;
    public static List<Color> colorlist;
    public GameObject cubeprefab;
    public float timetospawn = 2f;
    private float timeafterspawn = 2f;

	void Start ()
    {
        colorlist = new List<Color>();
        addcolors();
        StartCoroutine(spawntime());
    }
	
	
	void Update ()
    {
        if (Time.time >= timetospawn)
        {
            spwanblocks();
            timetospawn = Time.time + timeafterspawn;
            
            
        }
            

    }


    void spwanblocks()
    {
        int randomIndex = Random.Range(0, spawnpoints.Length);
        List<Color> col = new List<Color>(colorlist);
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            //if (randomIndex != i)
            {
              GameObject g = Instantiate(cubeprefab, spawnpoints[i].position, Quaternion.identity) as GameObject;
                randomIndex = Random.Range(0, col.Count);
                g.GetComponent<Renderer>().material.color = col[randomIndex];
                col.RemoveAt(randomIndex);

            }
        }
    }
    void addcolors()
    {
        colorlist.Add(Color.red);
        colorlist.Add(Color.white);
        colorlist.Add(Color.blue);
        colorlist.Add(Color.green);
        colorlist.Add(Color.yellow);
    }

    IEnumerator spawntime()
    {
        while(true)
        {
            timetospawn -= 0.1f;
            yield return new WaitForSeconds(3f);
        }
    }
}

