using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO ANIMATIONS:
/// 1. Shooting
/// 2. Squishing (IDLE)
/// 3. Squished (TURNING)
/// 4. Squished (MOVING)
/// 5. Hurt Animation
/// </summary>
public class BurgerController : MonoBehaviour {
    Animator animator;
    Rigidbody rig;
    public GameObject raycastPoint;
    Collectibles manager;
    
    public bool joystick = false;
    float airVelocity = 0f;

    void Start () {
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        airVelocity = 0;
        manager = FindObjectOfType<Collectibles>();
        
	}
	
	// Update is called once per frame
	void Update () {
        readKeyboard();
        readJoystick();
        checkGround();
        layerCheck();
    }

    public GameObject cheese;
    public GameObject tomato;
    public GameObject lettuce;
    public void layerCheck() {
        cheese.SetActive(manager.getCheese());
        tomato.SetActive(manager.getTomato());
        lettuce.SetActive(manager.getLettuce());
    }
    //Checks if there is solid ground under
    void checkGround() {
        Ray ray = new Ray(raycastPoint.transform.position, Vector3.down);
        RaycastHit hit;
        //bool grounded = Physics.Raycast(ray, out hit, 2f, 1 << 8);
         bool grounded = Physics.Raycast(ray, out hit, 2f);
        animator.SetBool("Grounded", grounded);
        animator.applyRootMotion = true;
    }

    void readKeyboard() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("Jump", true);
            joystick = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            animator.SetBool("Jump", false);
            rig.angularVelocity = Vector3.zero;
            joystick = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rig.angularVelocity = new Vector3(rig.angularVelocity.x, -4, 0);
            animator.SetBool("Turning", true);
            joystick = false;
        } 
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            rig.angularVelocity = Vector3.zero;
            animator.SetBool("Turning", false);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            rig.angularVelocity = new Vector3(rig.angularVelocity.x, 4, 0);
            joystick = false;
            animator.SetBool("Turning", true);
            //transform.Rotate(0, 4, 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            rig.angularVelocity = Vector3.zero;
            animator.SetBool("Turning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("HighJump", true);
            joystick = false;
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            animator.SetBool("Shoot", true);
        }
        animator.SetBool("Fast", Input.GetKey(KeyCode.LeftShift));
        //animator.SetBool("Squished", Input.GetKey(KeyCode.Z));
        
        
    }

    
    void readJoystick() {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.85f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.85f) {
            Vector3 dir = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")));

            
            
            if (animator.GetBool("HighJump") && !animator.GetBool("Grounded")) {
                float airAngelDiff = Mathf.Abs(Vector3.Angle(dir, airForward));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(airForward), 0.1f);
                airVelocity = Mathf.Lerp(airVelocity, 0.9f, 0.01f);
                transform.position += airForward * airVelocity;
            } else {
                dir = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);
                animator.SetBool("Jump", true);
            }
            joystick = true;
        } else if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.8f) {
            Vector3 dir = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.1f);
            animator.SetBool("Turning", true);
            joystick = true;
        } else if (joystick) {
            if (animator.GetBool("HighJump") && !animator.GetBool("Grounded")) {
                airVelocity = Mathf.Clamp(airVelocity - 0.2f, 0, airVelocity);
                transform.position += airForward * airVelocity;
            }
            animator.SetBool("Jump", false);
            rig.angularVelocity = Vector3.zero;
            animator.SetBool("Turning", false);
            rig.angularVelocity = Vector3.zero;
            airVelocity = 0.4f;
        }

        if (Input.GetButtonDown("Jump")) {
            animator.SetBool("HighJump", true);
            joystick = true;
        }
    }

    Vector3 airForward;
    public void jump() {
        //rig.isKinematic = true;
        Vector3 dir;
        if (joystick && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.3f && Mathf.Abs(Input.GetAxis("Vertical")) < 0.3f) {
            dir = transform.forward;
        } else {
            dir = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")));
        }
        rig.velocity = new Vector3(30, 45, rig.velocity.z);
        airForward = dir;
        //transform.position = transform.position + (transform.forward * 56);
        
    }

    public void endJump() {
        rig.isKinematic = false;
    }

    public void playParticle() {
        ParticleSystem part = GetComponentInChildren<ParticleSystem>();
        if (part) {
            part.Play();
        }
    }

    public void playAudio(AudioClip clip) {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager) {
            audioManager.playAudio(clip);
        }
    }
}
