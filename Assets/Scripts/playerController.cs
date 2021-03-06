using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject particle;
    [SerializeField]
    private float speed;
    public GameObject player;
    bool started; 
    Rigidbody rb;
    bool gameover;

    public Camera camera;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0) )
            {

               
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {

            gameover = true;

            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<cameraFall>().gameOver = true;

            GameManager.instance.GameOver();


        }


        if(Input.GetMouseButtonDown(0) && !gameover)
        {
            
             
                    player.GetComponentInChildren<Animator>().Play("Run_N");
                    SwitchDirection();
            
            
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z>0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
            transform.Rotate(0f, 90f, 0f);

        }
        else if(rb.velocity.x>0)
        {
            rb.velocity = new Vector3(0, 0, speed);
            transform.Rotate(0f, -90f, 0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="diamond")
        {
            ScoreManager.instance.startScore();

            GetComponent<AudioSource>().Play();
            GameObject part =  Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            

            Destroy(other.gameObject);
            Destroy(part,1f);

        }
    }
}
