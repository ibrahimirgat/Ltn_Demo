using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;
    public float speed = 5;
    float horizontalInput;

    public Vector3 scaleChangetall , scaleChangeshort;
    public Transform talldenem;
    public Transform shortdenem;

    [System.Obsolete]
    private void Start()
    {
        talldenem.GetComponent<ParticleSystem>().enableEmission = false;
        shortdenem.GetComponent<ParticleSystem>().enableEmission = false;
        scaleChangetall = new Vector3(0.1f, 0.1f, 0.1f);
        scaleChangeshort = new Vector3(-0.1f, -0.1f,-0.1f);
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    [System.Obsolete]
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door1")
        {
          tallfun();                    
        }
        if (other.tag == "Door2")
        {
            shortfun();
        }
    }

    [System.Obsolete]
    void tallfun()
    {
        gameObject.transform.localScale += scaleChangetall;
        talldenem.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(partefectdelay());
    }

    [System.Obsolete]
    void shortfun()
    {
        gameObject.transform.localScale += scaleChangeshort;
        shortdenem.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(partefectdelay());
    }

    [System.Obsolete]
    IEnumerator partefectdelay()
    {
        yield return new WaitForSeconds(1.5f);
        talldenem.GetComponent<ParticleSystem>().enableEmission = false;
        shortdenem.GetComponent<ParticleSystem>().enableEmission = false;
    }
  }