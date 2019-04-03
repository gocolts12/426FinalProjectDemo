using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_AI
{
    public class CatAIScript : MonoBehaviour
    {
        public GameObject Cat;
        public GameObject Player;
        public GameObject Ball;

        public int state;
        public bool follow = true;

        private CharacterController controller;
        private Animator animator;

        public float gravity = 20f;
        private Vector3 dir;
        public float speed = 1;
        public float step = 0;
        public Vector3 endpos;
        // Start is called before the first frame update
        void Start()
        {
            controller = Cat.GetComponentInChildren<CharacterController>();
            animator = Cat.GetComponentInChildren<Animator>();

            animator.SetBool("relax", false);
            animator.SetBool("sit", false);
            animator.SetBool("stand", false);
            animator.SetBool("walk", false);

            state = 3;

            endpos = Ball.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            dir.y -= gravity * Time.deltaTime;
            controller.Move(dir * Time.deltaTime);

            if (controller.isGrounded)
            {
                if (state == 0) //Default state, cat is laying on the ground
                {
                    animator.SetBool("relax", true);
                    animator.SetBool("sit", false);
                    animator.SetBool("stand", false);
                    animator.SetBool("walk", false);
                }
                else if (state == 1) //Sit state, cat is sitting up and facing the target
                {
                    animator.SetBool("relax", false);
                    animator.SetBool("sit", true);
                    animator.SetBool("stand", false);
                    animator.SetBool("walk", false);

                    var relpos = endpos - Cat.transform.position;
                    var rot = Quaternion.LookRotation(relpos);
                    rot.x = 0;
                    rot.z = 0;
                    Cat.transform.rotation = rot;
                }
                else if (state == 2) //Stand state, cat is standing up and facing the target
                {
                    animator.SetBool("relax", false);
                    animator.SetBool("sit", false);
                    animator.SetBool("stand", true);
                    animator.SetBool("walk", false);

                    var relpos = endpos - Cat.transform.position;
                    var rot = Quaternion.LookRotation(relpos);
                    rot.x = 0;
                    rot.z = 0;
                    Cat.transform.rotation = rot;
                }
                else if (state == 3) //Walk state, cat is walking towards its target
                {
                    animator.SetBool("relax", false);
                    animator.SetBool("sit", false);
                    animator.SetBool("stand", false);
                    animator.SetBool("walk", true);

                    step = speed * Time.deltaTime;

                    Cat.transform.position = Vector3.MoveTowards (Cat.transform.position, endpos, step);
                    var relpos = endpos - Cat.transform.position;
                    var rot = Quaternion.LookRotation(relpos);
                    rot.x = 0;
                    rot.z = 0;
                    Cat.transform.rotation = rot;
                }
                else if (state == 4)
                {
                    animator.SetBool("relax", false);
                    animator.SetBool("sit", false);
                    animator.SetBool("stand", false);
                    animator.SetBool("walk", true);

                    step = speed * Time.deltaTime;

                    Cat.transform.position = Vector3.MoveTowards(Cat.transform.position, endpos, step);
                    var relpos = endpos - Cat.transform.position;
                    var rot = Quaternion.LookRotation(relpos);
                    rot.x = 0;
                    rot.z = 0;
                    Cat.transform.rotation = rot;
                }
                if (Vector3.Distance(Cat.transform.position, endpos) < 0.4)
                {
                    state = 1;
                }
            }

        }
        
        public void SetState(int goal_state)
        {
            state = goal_state;
        }
    }
}