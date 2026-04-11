using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarControlScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    private float originalSpeed;
    private bool isSlowed = false;
    private bool isBoosted = false;
    private IEnumerator dumpRoutine;
    private IEnumerator boostedRoutine;
    private Rigidbody2D _rb;
    private BoosterSpawnScript _spawnScript;
    private AudioSource _engineSource;
    private float _enginePitch;
    private ClockSpawnScript _clockScript;

    private void Start()
    {
        _spawnScript=FindAnyObjectByType(typeof(BoosterSpawnScript)) as BoosterSpawnScript;
        _clockScript=FindAnyObjectByType(typeof(ClockSpawnScript)) as ClockSpawnScript;
        _rb = GetComponent<Rigidbody2D>();
        originalSpeed  = moveSpeed;
        _engineSource= GetComponent<AudioSource>();
        _enginePitch=_engineSource.pitch;
    }

    public void Moving(float moveValue)
    {
        Vector3 direction = Vector3.up * moveValue;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        _engineSource.pitch = 1f + 0.01f * moveSpeed;
        
    }

    public void Turning(float turnValue)
    {
        var turn = turnValue * turnSpeed;
        transform.Rotate(0,0,turn*Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DumpTag"))
        {
            if (isSlowed && dumpRoutine != null)
            {
                StopCoroutine(dumpRoutine);
            }
            AudioManagerScript.instance.DumpSound();
            dumpRoutine = Slow();
            StartCoroutine(dumpRoutine);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickupBoost"))
        {
            if(isBoosted && boostedRoutine != null)
            {
                StopCoroutine(boostedRoutine);
            }
            boostedRoutine = Boosted();
            StartCoroutine(boostedRoutine);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("ClockTag"))
        {
            GameManagerScript.Instance.time += 10;
            Destroy(other.gameObject);
            _clockScript.RandomClockRandomSpawn();
            AudioManagerScript.instance.GetClock();
            UIManagerScript.instance.timeAnimation();
        }
    }

    IEnumerator Slow()
    {
        moveSpeed=originalSpeed*0.5f;
        isSlowed = true;
        Debug.Log("Your Speed is Half");
        
        yield return new WaitForSeconds(1.5f);
        
        isSlowed = false;
        moveSpeed = originalSpeed;
        Debug.Log("Your Speed is Normal");
        dumpRoutine = null;
        
    }

    IEnumerator Boosted()
    {
        moveSpeed=originalSpeed * 1.5f;
        isBoosted = true;
        
        yield return new WaitForSeconds(2f);
        
        _spawnScript.RandomSpawn();
        isBoosted = false;
        moveSpeed = originalSpeed;
        boostedRoutine = null;
    }

    public void ResetPitch()
    {
        _engineSource.pitch = _enginePitch;
    }
    
    public void StopEngine()
    {
        _engineSource.Stop();
    }

}
