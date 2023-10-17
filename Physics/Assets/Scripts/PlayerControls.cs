using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Variables
    public CharacterController controller;
    public Animator anim;
    public AudioClip runningSound;
    AudioSource audioSource;

    public bool playerOneControls = true;
    public bool playerTwoControls;
    public float runningSpeed = 4;
    public float gravity = 8;
    public bool freeRotation = true;
    public float freeRotationSpeed = 90;
    public bool running = false;
    private float rot = 0f;


    public Vector3 moveDir = Vector3.zero;

    // Starting Function
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
        audioSource = GetComponent<AudioSource>();
    }

    // Game Loop
    // Update is called once per frame
    void Update()
    {
        // When player presses Up Arrow, character moves forward.
        // When player presses Right or Left Arrow keys, character rotates direction.
        if (playerOneControls == true){
            if (controller.isGrounded){
                if (Input.GetKey(KeyCode.UpArrow)){
                    anim.SetBool("Run Forward", true);
                    running = true;
                    moveDir = new Vector3 (0, 0, 1);
                    moveDir *= runningSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                    if(audioSource != null && !audioSource.isPlaying){
                        audioSource.clip = runningSound;
                        audioSource.Play();
                    }
                } else {
                    anim.SetBool("Run Forward", false);
                    moveDir = new Vector3 (0, 0, 0);
                    running = false;
                    if(audioSource != null && audioSource.isPlaying){
                        audioSource.Stop();
                    }
                }

                if (Input.GetKey(KeyCode.Space)){
                    Debug.Log("JUMP");
                    if (running){
                        float slightMove = 0.5f;
                        moveDir = new Vector3 (0, 2, slightMove);
                    } else {
                        moveDir = new Vector3 (0, 2, 0);
                    }
                    moveDir *= runningSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                }

                if (freeRotation == true){
                    if (Input.GetKey(KeyCode.RightArrow)){
                        rot += freeRotationSpeed * Time.deltaTime;
                        transform.eulerAngles = new Vector3 (0, rot, 0);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow)){
                        rot -= freeRotationSpeed * Time.deltaTime;
                        transform.eulerAngles = new Vector3 (0, rot, 0);
                    }
                } else {
                    if (Input.GetKey(KeyCode.RightArrow)){
                        transform.Rotate(0, 90, 0, Space.World);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow)){
                        transform.Rotate(0, -90, 0, Space.World);
                    }
                }
            }
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }

        if (playerTwoControls == true){
            if (controller.isGrounded){
                if (Input.GetKey(KeyCode.W)){
                    anim.SetBool("Run Forward", true);
                    running = true;
                    moveDir = new Vector3 (0, 0, 1);
                    moveDir *= runningSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                    if(audioSource != null && !audioSource.isPlaying){
                        audioSource.clip = runningSound;
                        audioSource.Play();
                    }
                } else {
                    anim.SetBool("Run Forward", false);
                    moveDir = new Vector3 (0, 0, 0);
                    running = false;
                    if(audioSource != null && audioSource.isPlaying){
                        audioSource.Stop();
                    }
                }

                if (Input.GetKey(KeyCode.S)){
                    anim.SetBool("Jump", true);
                    if (running){
                        float slightMove = 0.5f;
                        moveDir = new Vector3 (0, 2, slightMove);
                    } else {
                        moveDir = new Vector3 (0, 1, 0);
                    }
                    moveDir *= runningSpeed;
                    moveDir = transform.TransformDirection(moveDir);
                    } else {
                    anim.SetBool("Jump", false);
                }

                if (freeRotation == true){
                    if (Input.GetKey(KeyCode.D)){
                        rot += freeRotationSpeed * Time.deltaTime;
                        transform.eulerAngles = new Vector3 (0, rot, 0);
                    }
                    if (Input.GetKey(KeyCode.A)){
                        rot -= freeRotationSpeed * Time.deltaTime;
                        transform.eulerAngles = new Vector3 (0, rot, 0);
                    }
                } else {
                    if (Input.GetKey(KeyCode.D)){
                        transform.Rotate(0, 90, 0, Space.World);
                    }
                    if (Input.GetKey(KeyCode.A)){
                        transform.Rotate(0, -90, 0, Space.World);
                    }
                }
            }
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}
