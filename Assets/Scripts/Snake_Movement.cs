using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Snake_Movement : MonoBehaviour
{
    public Animator animator;
    public GameObject Canvas;
    private List<Transform> _segments;
    public Transform segmentPrefab; 
    public int score=1;
    public float timer = 0;
    public float timerMax = 1;
    public Vector2 _direction = Vector2.zero;
    public Generator generator;
    public bool alive= false;
    // Start is called before the first frame update
    private void Awake() {

    }
    void Start()
    {
      generator = GameObject.FindWithTag("MainCamera").GetComponent<Generator>();
      _segments = new List<Transform>();
      _segments.Add(this.transform);   
      animator = Canvas.GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    //handle input
    if(Input.GetKeyDown(KeyCode.UpArrow) && _direction != Vector2.down )
        {
            _direction = Vector2.up;
        }
    else if(Input.GetKeyDown(KeyCode.DownArrow) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
    else if(Input.GetKeyDown(KeyCode.LeftArrow) && _direction != Vector2.right)
            {
            _direction = Vector2.left;
            }
    else if(Input.GetKeyDown(KeyCode.RightArrow) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        } 
        if(!alive){
            transform.position = new Vector3(0,0,0);
        }
 
    
   
}

private void FixedUpdate() {
     //handle growth
    for(int i= _segments.Count-1;i>0;i--){
        _segments[i].position = _segments[i-1].position;
    }

    
    transform.eulerAngles = new Vector3(0,0,GetAngleFromVecot(_direction));
    this.transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x,
        Mathf.Round(this.transform.position.y) + _direction.y,
        0f
    );    
}


private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Food"){
        Destroy(other.gameObject);
        score++;
        Grow();
    }
    if(other.gameObject.tag == "Segment" || other.gameObject.tag=="Wall"){
       GameOver();
       }
    
    
}

public void GameOver(){
 _direction = Vector2.zero;
animator.SetTrigger("GameOver");
generator.Gen();
Debug.Log("Game Over");
}

public float GetAngleFromVecot(Vector2 Dir){
    float n = Mathf.Atan2(Dir.y,Dir.x) * Mathf.Rad2Deg;
    if(n<0) n+=360;
    return n;
}

public void Grow(){
    Transform segment = Instantiate(this.segmentPrefab);
    segment.position = _segments[_segments.Count-1].position;
    _segments.Add(segment);
}
public void play(){
    animator.SetTrigger("Play");
    generator.Gen();
    _direction = Vector2.right;
    alive = true;
    Grow();
    
}


public void Restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}