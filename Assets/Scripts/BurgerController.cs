using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// TODO ANIMATIONS:
/// 1. Shooting
/// 2. Squishing (IDLE)
/// 3. Squished (TURNING)
/// 4. Squished (MOVING)
/// 5. Hurt Animation
/// </summary>
public class BurgerController : MonoBehaviour {
    public DoAction doAction;
    public PowerUpManager powerUpManager;
    Animator animator;
    Rigidbody rig;
    public HealthUIManager healthUIManager;
    public GameObject raycastPoint;
    public GroundCheck groundCheck;
    Collectibles manager;
    public int health = 3;

    public bool joystick = false;
    float airVelocity = 0f;

    public bool invincible = false;

    void Start () {

        doAction = GetComponent<DoAction>();
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        airVelocity = 0;
        manager = FindObjectOfType<Collectibles>();
        Collectibles.pickle_acquired = false;
        Collectibles.cheese_acquired = false;
        Collectibles.tomato_acquired = false;
        Collectibles.lettuce_acquired = false;
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
        if (!FindObjectOfType<PowerUpManager>().tomato_enabled) {
            animator.SetBool("Squished", false);
        }
    }
    //Checks if there is solid ground under
    void checkGround() {
        Ray ray = new Ray(raycastPoint.transform.position, Vector3.down);
        RaycastHit hit;
        //bool grounded = Physics.Raycast(ray, out hit, 2f, 1 << 8);
        //bool grounded = Physics.Raycast(ray, out hit, 2f);
        bool grounded = groundCheck.check;
        animator.SetBool("Grounded", grounded);
        animator.applyRootMotion = true;
    }

    void readKeyboard() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("Jump", true);
            joystick = false;
        }
        if (!joystick) {
            if (animator.GetBool("HighJump") && !animator.GetBool("Grounded")) {
                //float airAngelDiff = Mathf.Abs(Vector3.Angle(dir, airForward));
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(airForward), 0.1f);
                airVelocity = Mathf.Lerp(airVelocity, 0.9f, 0.625f * Time.deltaTime);
                transform.position += transform.forward * ((62.5f * Time.deltaTime) * airVelocity);
            }
            if (animator.GetBool("Grounded")) {
                airVelocity = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            animator.SetBool("Jump", false);
            joystick = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(new Vector3(0, -5f, 0));
            //rig.angularVelocity = new Vector3(rig.angularVelocity.x, -4, 0);
            animator.SetBool("Turning", true);
            joystick = false;
        } else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            rig.angularVelocity = Vector3.zero;
            animator.SetBool("Turning", false);
        } else {
            rig.angularVelocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(new Vector3(0, 5f, 0));
            //rig.angularVelocity = new Vector3(rig.angularVelocity.x, 4, 0);
            joystick = false;
            animator.SetBool("Turning", true);
            //transform.Rotate(0, 4, 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            rig.angularVelocity = Vector3.zero;
            animator.SetBool("Turning", false);
        }

        animator.SetBool("Fast", (Input.GetKey(KeyCode.LeftShift)|| Input.GetKeyDown("joystick button 10")));
        
        
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

        //if (Input.GetButtonDown("Jump")) {
        //    animator.SetBool("HighJump", true);
        //    joystick = true;
        //}
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


    void OnTriggerStay(Collider other) {



        if (!invincible && other.gameObject.tag == "Enemy" && doAction.shield_on == false) {
            health -= 1;
            if (health <= 0) {
                animator.SetBool("Dead", true);
                invincible = true;
                ScreenTransition transition = FindObjectOfType<ScreenTransition>();
                if (transition) {
                    transition.fadeInToLevel(SceneManager.GetActiveScene().buildIndex);
                }
                rig.constraints = RigidbodyConstraints.FreezeAll;
            } else {
                animator.SetBool("Damage", true);
                StartCoroutine(hurtBufferPeriod(1.3f));
            }
            
        }

        if (!invincible && other.gameObject.tag == "Fire" && doAction.shield_on == false)
        {

            health -= 1;
            if (health <= 0)
            {
                animator.SetBool("Dead", true);
                invincible = true;
                ScreenTransition transition = FindObjectOfType<ScreenTransition>();
                if (transition)
                {
                    transition.fadeInToLevel(SceneManager.GetActiveScene().buildIndex);
                }
                rig.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                animator.SetBool("Damage", true);
                StartCoroutine(hurtBufferPeriod(1.3f));
            }

        }
    }

    

    //Buffer period between getting hurt when you're invincible.
    IEnumerator hurtBufferPeriod(float waitTime) {
        invincible = true;
        yield return new WaitForSeconds(waitTime);
        invincible = false;
    }

    
}
