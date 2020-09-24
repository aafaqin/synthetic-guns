using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour
{
    public CharacterController controller;
    public GameObject playerobj;
    public float speed = 6f;
    private float cur_height;
    GameObject[] gos;
    public Camera cam;
    int startno=309;
    bool pause=false;
    Rigidbody rb ;
    Vector3 vel ;
    int img_mul=12;             // change to change the size the images getting genereated 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vel = rb.velocity;
        // Random.seed=startno;
        Random.InitState(startno);
        //transform.position = new Vector3(24.3999996f,26.1800003f,-25f);
        cur_height=transform.position.y;
        // cam = GetComponent<Camera>();
        // //get all the objects with the tag "myTag"
        gos = GameObject.FindGameObjectsWithTag("myguns");

    }

    // Update is called once per frame
    void Update()
    {

        //randomtest
        rb = GetComponent<Rigidbody>();
        vel = rb.velocity;



        if(pause){

            //take screenshot

            reset_player();
            Time.timeScale=3;
            pause=false;
            rb.velocity=Vector3.zero;

        }
        else
        {
          
        // change bg color
        //   float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = UnityEngine.Random.ColorHSV();

        //use these variables to set and check the velocity of the rigidbody associated with the player
       

       //if the hight if the player is more than 33 now keep switching the player randomly 
            if(controller.transform.position.y>45f){
                Debug.Log(controller.transform.position.y);
                ChangePlayer();
            }
        
// ////////////////// test velocity of player code
       
            if (vel.magnitude > 0) {
                //  rb.velocity = vel.normalized * maxSpeed;
                Debug.Log("the speed is "+vel.magnitude);
            }

            if (vel.magnitude > 50) {
                //  rb.velocity = vel.normalized * maxSpeed;
                Debug.Log("fallen angel"+vel.magnitude);

                Time.timeScale = 0;
                pause=true;
                ScreenCapture.CaptureScreenshot("/media/aafaq/work_drive/synthetic_guns_dataset/gun"+startno+"a.png",img_mul);

                
            }

//////////////

    // the object is on ground now
        // if(vel.magnitude <= 0.1 && controller.transform.position.y <= 80f){
            else  if(vel.magnitude <= 0.1 && controller.transform.position.y <= 80f){
                Debug.Log("the weapon has reached ground now");
                Debug.Log("vel.magnitude"+vel.magnitude);
                pause=true;
                Time.timeScale=0;
                 
                ScreenCapture.CaptureScreenshot("/media/aafaq/work_drive/synthetic_guns_dataset/gun"+startno+"a.png",img_mul);

                
                
            }
        // Debug.Log(playerobj.velocity.magnitude);
    }
}
    void reset_player(){
            
          

            ScreenCapture.CaptureScreenshot("/media/aafaq/work_drive/synthetic_guns_dataset/gun"+startno+"b.png",img_mul);
              startno++;
            //lets go back to the sky and jump again 
            // controller.transform.position.y=33.1f;
            //finding the limits of maps in X and z dimension
            // making it the limits of random 2d plane of height y=33.1f to spawn from
            //x=165 -96.4
            //z=112.7  -182.6
            // controller.transform.position = new Vector3(4f, 33.1f , -30f);
            // add randomness in y if want
            controller.transform.position = new Vector3(Random.Range(-96.4f, 165.0f), 88.1f, Random.Range(112.7f, -182.6f));
            // controller.transform.position = new Vector3(controller.transform.position.x, 33.1f , controller.transform.position.z);
            // the player keeps  context of previous veclocity flyin here and there so make velocit zero when we reset the player location
            
            
            Debug.Log("lets go back to the sky and jump again with a new gun yeah!!!");
    }


    void ChangePlayer(){
         //disable all guns objects myguns
       
        
        // //loop through the returned array of game objects and set each to active false
        foreach (GameObject go in gos){
        go.SetActive(false);
        // Debug.Log(go.name);
        // Debug.Log("is false");
        }
        // Random r= new Random();
        int rInt=Random.Range(0,gos.Length);
        gos[rInt].SetActive(true);
        // Debug.Log(rInt);
        // Debug.Log("was the random int");
        // Debug.Log(gos[rInt].name);

        // gos[1].SetActive(true);
    }
}
