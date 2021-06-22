using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator Animator;
    Rigidbody Rigidbody;
    AudioSource AudioSource;
    Vector3 Movement;
    Quaternion Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Movement.Set(horizontal, 0f, vertical);
        Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
        }
        else
        {
            AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, Movement, turnSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        Rigidbody.MovePosition(Rigidbody.position + Movement * Animator.deltaPosition.magnitude);
        Rigidbody.MoveRotation(Rotation);
    }
}
