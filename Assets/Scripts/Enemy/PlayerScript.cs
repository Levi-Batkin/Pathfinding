using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Events;
namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Transform enemy;					// Whether or not a player can steer while jumping;			// A collider that will be disabled when crouching

        private Rigidbody m_Rigidbody;
        private Vector3 m_Velocity = Vector3.zero;

        [Header("Events")]
        [Space]

        public UnityEvent OnLandEvent;

        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        public BoolEvent OnCrouchEvent;

        public Rigidbody rb;
        Collision col;
        public SpriteHelper sh;
        public LayerMask platformLayerMask;
        public float platformRadius;
        public bool onPlatform;
        public bool jumpFlag, jumpButtonPressed, jumpButtonReleased;
        public bool shootButtonPressed, shootButtonReleased;
        public bool crouchButtonPressed, crouchButtonReleased;
        public bool upButtonPressed, downButtonPressed;

        public float fall = 0.2f;
        public float jumpGravity = 0.6f;
        public float initialJumpVel = 10f;
        public float xv, yv;

        

        Dir lastDir;
        public Dir currentDir;


        public float runSpeed = 6;

        

        LevelManager lm;


        // variables holding the different player states
        public StandingState standingState;
        public RunningState runningState;
        public StateMachine sm;
        public UnityEngine.AI.NavMeshAgent agent;
        public Transform player;
        private void Awake()
        {
            sh = gameObject.AddComponent<SpriteHelper>();
            m_Rigidbody = GetComponent<Rigidbody>();

            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();

            if (OnCrouchEvent == null)
                OnCrouchEvent = new BoolEvent();
        }




        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            col = gameObject.AddComponent<Collision>();
            lm = LevelManager.lm;
            sm = gameObject.AddComponent<StateMachine>();

            // add new states here
            standingState = new StandingState(this, sm);
            runningState = new RunningState(this, sm);
            // initialise the statemachine with the default state
            sm.Init(standingState);         

        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            /*
            string s;
            s = string.Format("onplat={0} jumpFlag={1}\nlast state={2}\ncurrent state={3}", onPlatform, jumpFlag, sm.LastState, sm.CurrentState);
            UIscript.ui.DrawText(s);

            s = string.Format("current dir2={0} lastdir={1} yv={2}", currentDir, lastDir, yv);
            UIscript.ui.DrawText(s);

            s = string.Format("shoot button={0} ", shootButtonPressed);
            UIscript.ui.DrawText(s);

            // Press R to reset the player's position
            DebugPlayer();
            */
        }


        void FixedUpdate()
        {
          
            sm.CurrentState.PhysicsUpdate();
            
        }
        public bool CheckForMove()
        {
            float chaseDist=2;
            float dist = Vector3.Distance(player.position, enemy.position);
            if(dist < chaseDist)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}