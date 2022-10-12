
using UnityEngine;
namespace Player
{
    public class StandingState : State
    {


        // constructor
        public StandingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.agent.SetDestination(player.gameObject.transform.position);
        }

        public override void Exit()
        {
            base.Exit();

        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (player.CheckForMove())
            {
                player.sm.ChangeState(player.runningState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}