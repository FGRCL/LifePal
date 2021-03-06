﻿using UnityEngine;

namespace Assets.Scripts
{
    class DogBehaviour : MonoBehaviour, TouchObserver
    {
        private TouchSubject touchSubject;
        private GameObject reticle;
        private float speed;
        private Animator animator;
        private Vector3 target;
        private bool hasTarget = false;

        void Start()
        {
            touchSubject = GameObject.FindGameObjectsWithTag("TouchObserver")[0].GetComponent<TouchSubject>();
            reticle = GameObject.FindGameObjectsWithTag("Reticle")[0];
            animator = GetComponent<Animator>();
            touchSubject.Subscribe(this);
            speed = 1.5f;
        }

        void Update()
        {
            if (hasTarget)
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.LookAt(target);
                transform.position = Vector3.MoveTowards(transform.position, target, step);
                if (Vector3.Distance(transform.position, target) < 0.001f)
                {
                    hasTarget = false;
                    animator.SetFloat("Move", 0.0f);
                }
            }
        }

        public void OnTouch()
        {
            target = reticle.transform.position;
            hasTarget = true;
            animator.SetFloat("Move", 1.6f);
        }

         void OnMouseDown()
        {
            hasTarget = false;
            animator.SetTrigger("bark");
        }
    }   
}
