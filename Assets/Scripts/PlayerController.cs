using System;
using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour 
{
    public delegate void GetScoreHandler(int score);
    public delegate void WinHandler();
    public static event GetScoreHandler OnGetScore;
    public static event WinHandler OnWin;
    
    public float speed = 300f;
    public int winScore = 12;
    
    private int _score;

    Rigidbody playerRigidbody;
    Vector3 movement;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        _score = 0;
    }

	void Update()
    {
        movement = new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
        ) * speed;
    }
    
    void FixedUpdate()
    {
        playerRigidbody.AddForce(movement * Time.fixedDeltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            Destroy(other.gameObject);
            
            _score++;
            DispatchGetScoreEvent();
            if (_score == winScore){
                DispatchWinEvent();
            }
        }
    }

    private void DispatchWinEvent()
    {
        if (OnWin != null)
        {
            OnWin();
        }
    }

    private void DispatchGetScoreEvent()
    {
        if (OnGetScore != null)
        {
            OnGetScore(_score);
        }
    }
}
