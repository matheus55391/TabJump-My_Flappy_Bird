﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BirdController : MonoBehaviour
{
    [SerializeField]
    private GameObject jumpAudio;
    [SerializeField]
    private ScoreCanvas score;
    [SerializeField]
    private GameObject gameMenu;
    [SerializeField]
    private float jumpforce = 10f;
    private Rigidbody2D rb;
    private bool _canJump=true;
    void Start()
    {
        _canJump =true;
        // YOU NEED SET GRAVITY SCALE TO 3
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

       // Pause();
        if(Input.GetKeyDown(KeyCode.A)){
            
            SceneManager.LoadScene("SampleScene");
        }

    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && _canJump == true || _canJump == true && Input.GetMouseButtonDown(0)){
            //on press space will jump
            //Debug.Log("SPACE");
            Instantiate(jumpAudio,Vector3.down, Quaternion.identity);
            rb.velocity = Vector2.up * jumpforce;
            this.gameObject.GetComponent<Animator>().Play("jump");
        }
    }
    
    void OnCollisionEnter2D (Collision2D collision){

        if(collision.gameObject.tag == "die"){
            _canJump = false;
            Time.timeScale = 0; 
            gameMenu.SetActive(true);
            score.check_record();
        }

    }   

}
