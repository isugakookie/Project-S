﻿using System.Collections.Generic;
using Characters.Enemy;
using UnityEngine;
using Characters;
using Motion = Characters.Motion;

namespace Finite_State_Machine.States
{
    public class WalkToLocation : State
    {
        private List<Vector3> roadPath;
        
        public WalkToLocation()
        {
            interval = 0f;
        }
        
        protected override void Initialize(MoveableObject agent) 
        {
            var grid = agent.grid;
            
            var pos = agent.Position();
            var tar = agent.TargetLocation;

            roadPath = grid.CreatePath(pos, tar);

            switch (agent)
            {
                case Character:
                    agent.CalculateDirection();
                    agent.SetAnimations(Motion.Walk);
                    break;
                case Enemy:
                    agent.SetAnimations(Action.Jump);
                    break;
            }

            CurrentStatus = StateStatus.Executing;
        }

        protected override void Executing(MoveableObject agent)
        {
            if (roadPath != null && roadPath.Count != 0)
            {
                agent.TargetLocation = roadPath[0];

                if (agent.IsAtPosition()) roadPath.RemoveAt(0);

                if (roadPath.Count == 0)
                {
                    roadPath = null;
                    CurrentStatus = StateStatus.Completed;
                }

                Move(agent);
            }
        }

        protected override void Completed(MoveableObject agent)
        {
            agent.IsSubState();
        }
        
        private static void Move(MoveableObject agent)
        {
            var pos = agent.Position();
            var tar = agent.TargetLocation;

            var speed = agent switch
            {
                Enemy enemy => enemy.SPE,
                Character player => player.SPE * 10,
                _ => 0f
            };
            
            var towards = Vector2.MoveTowards(pos, tar, speed * Time.deltaTime);
            agent.SetPosition(towards);
        }
    }
}