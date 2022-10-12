
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {


        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.agent.SetDestination(player.enemy.position);

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

            // check for ground
            // check for wall collision
            // check for stand
            if (player.CheckForMove() == false)
            {
                player.sm.ChangeState(player.standingState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}