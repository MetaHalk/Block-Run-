using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject platform;
    Vector3 lastpos;
    float size;
    public GameObject diamonds;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i<20; i++)
        {
            SpawnPlatfroms();
        }

       
    }



    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameover==true)
        {
            CancelInvoke("SpawnPlatforms");
          
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;

        lastpos = pos;

        Instantiate(platform, pos,Quaternion.identity);
        int rand = Random.Range(0, 4);

        if(rand<1)
        {
            Instantiate(diamonds, new Vector3(pos.x,pos.y+1, pos.z), diamonds.transform.rotation);
        }
        
    }


    public void StartPlatformSpawner()
    {
        InvokeRepeating("SpawnPlatfroms", 0.1f, 0.2f);
    }


    void SpawnPlatfroms()
    {
       
        int rand = Random.Range(0, 6);

        if(rand<3)
        {
            SpawnX();
        }

        else if(rand>=3)
        {
            SpawnZ();
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
}
