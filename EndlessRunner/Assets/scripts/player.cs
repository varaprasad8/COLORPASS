using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {


    private Rigidbody rb;

    public AudioClip pass;
    public AudioClip go;
    public AudioSource gplay;

    public Button QB;

    public GameObject gameOver;

    int score=1;
    public Text SC;
    public Text HS;

    public float timer;
    public float maxTime;
    public float maxSpeed;
    public int maxScore;
    [Range(0.1f,1.0f)]
    public float difficultyLevel;

    //private float timefornextspawn = 2f;
    bool scoreUpdated=true;

    Material mat;
    int colorIndex = -1;

    [SerializeField] private float speed = 15f;
    private float screenwidth = 6f;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        mat = GetComponent<MeshRenderer>().material;
        mat.color = Color.red;
        score = 0;
        SC.text = score.ToString();
        gplay.clip = go;
        gplay.clip = pass;
        //InvokeRepeating("colorchange", 2f,2f);
        HS.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameOver.SetActive(false);
        
        
	}
    private void Update()
    {
        //Debug.Log(timer);
        timer += Time.deltaTime;
        if(timer>maxTime)
        {
            //score += 1;
            timer = 0;
            SC.text = score.ToString();
        }
        Cube.speed = maxSpeed;
        if(maxScore>50)
        {
            maxScore = 0;
            score++;
        }
        highScore();
        //score = maxScore;
    }


    void FixedUpdate()
    {

        #region touchInput1
         if(Input.touchCount>0)
         {
             Touch touch = Input.GetTouch(0);
             Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
             Vector2 Pos = new Vector2(touchPos.x, rb.position.y);
             Pos.x = Mathf.Clamp(Pos.x, -screenwidth, screenwidth);
             rb.position = Pos;
         }
        #endregion

        /*float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        Vector3 mov = rb.position + Vector3.right * x;
       mov.x = Mathf.Clamp(mov.x, -screenwidth, screenwidth);
        rb.MovePosition(mov);*/

        //score = (int)Time.time;
       
       //Debug.Log(score);
        //SC.text = score.ToString();
        CheckScore();
        maxScore++;
       // colorchange();
    }

    void colorchange()
    {
        if (colorIndex == spwanner.colorlist.Count - 1)
            colorIndex = -1;
        mat.color = spwanner.colorlist[++colorIndex];

       /* if (Time.time>timefornextspawn)
        {
            if (colorIndex == spwanner.colorlist.Count - 1)
                colorIndex = -1;
            mat.color = spwanner.colorlist[++colorIndex];
            timefornextspawn = Time.time + spwanner.timetospawn;
        }*/
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color != mat.color)
            // Destroy(gameObject);
            //Debug.Log("destroy");
          
            transform.GetComponent<BoxCollider>().isTrigger = false;
        gplay.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.color == mat.color)
        {
           // Debug.Log("color");
            if (colorIndex == spwanner.colorlist.Count - 1)
                colorIndex = -1;
            //mat.color = spwanner.colorlist[++colorIndex];
            mat.color = spwanner.colorlist[Random.Range(0, spwanner.colorlist.Count)];
        }
    }

    void CheckScore()
    {
        if(score % 10 == 0 && scoreUpdated)
        {


            // Debug.Log("Speed =" + Cube.speed);
            // Cube.speed = Cube.speed + Cube.speed * difficultyLevel;
            maxSpeed += 1f;
            Cube.speed = maxSpeed;
            
           // maxScore++;
            
            
            scoreUpdated = false;
        }
        if(score%10==9)
        {
            scoreUpdated = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Cube")
        {
           // score = 0;
            //Debug.Log("restat");
            gplay.Play();
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            QB.interactable = false;

           // SceneManager.LoadScene(0);
        }
    }

    public void highScore()
    {
        SC.text = score.ToString();
        if(score>PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            HS.text ="HS: "+score.ToString();
        }

    }
    /*public void reset()
    {
        PlayerPrefs.DeleteAll();
        HS.text = "0";
    }*/
}   


