using System;
using UnityEngine;

namespace CJ.Scripts.GamePlay.State
{
    public class GamePlayState
    {
        protected enum Event
        {
            Enter,
            Update,
            Exit
        }

        protected Event nextEvent;
        protected GamePlayState nextStatus;

        public GamePlayState()
        {
            nextStatus = this;
        }

        public virtual GamePlayState Process()
        {
            switch (nextEvent)
            {
                case Event.Enter:
                    Enter();
                    break;
                case Event.Update:
                    Update();
                    break;
                case Event.Exit:
                    Exit();
                    break;
            }

            return nextStatus;
        }

        protected virtual void Enter()
        {
            nextEvent = Event.Update;
        }

        protected virtual void Update() { }

        protected virtual void Exit()
        {
            nextEvent = Event.Exit;
        }
    }
}
