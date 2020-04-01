using UnityEngine;

namespace Assets.Scripts
{
    class DogBehaviour : MonoBehaviour, TouchObserver
    {
        private TouchSubject touchSubject;
        private GameObject reticle;
        public float speed;
        private Animator animator;
        private Vector3 target;
        private bool hasTarget = false;

        void Start()
        {
            touchSubject = GameObject.FindGameObjectsWithTag("TouchObserver")[0].GetComponent<TouchSubject>();
            reticle = GameObject.FindGameObjectsWithTag("Reticle")[0];
            animator = GetComponent<Animator>();
            touchSubject.Subscribe(this);
        }

        void Update()
        {
            if (hasTarget)
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, target, step);
                if (Vector3.Distance(transform.position, target) < 0.001f)
                {
                    hasTarget = false;
                }
            }
        }

        public void OnTouch()
        {
            target = reticle.transform.position;
            hasTarget = true;
        }

         void OnMouseDown()
        {
            animator.SetTrigger("bark");
        }
    }   
}
