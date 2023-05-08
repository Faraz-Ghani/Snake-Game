using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject Food;
    public float timer = 0f;
    public float timerMax = 3f;
    public bool generate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(generate){
        if(timer > timerMax){
        float x =Random.Range(-8,8);
        float y =Random.Range(-4.5f,4.5f);
        Destroy(GameObject.FindWithTag("Food"));
        Instantiate(Food, new Vector3(x,y,0), Quaternion.identity);
        timer = 0f;
        }
    }
     timer += Time.deltaTime;
    }

    public void Gen(){
        generate = !generate;
    }
}
