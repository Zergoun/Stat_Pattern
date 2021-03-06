﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stat_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // create Context object and suplied current state or initial state (state A).
            Context context = new Context(new StateA());

            //Change state request from A to B.
            context.Request();

            //Change state request from B to C.
            context.Request();

            //Change state request from C to A.
            context.Request();

        }
        public interface StateBase
        {
            void Change(Context context);
        }

        public class StateA : StateBase
        {
            public void Change(Context context)
            {
                //Change state of context from A to B.
                context.State = new StateB();
                Console.WriteLine("Change state from A to B.");
            }
        }

        public class StateB : StateBase
        {
            public void Change(Context context)
            {
                //Change state of context from B to C.
                context.State = new StateC();
                Console.WriteLine("Change state from B to C.");
            }
        }
        public class StateC : StateBase
        {
            public void Change(Context context)
            {
                //Change state of context from C to A.
                context.State = new StateA();
                Console.WriteLine("Change state from C to A.");
                Console.ReadLine();
            }
        }

        public class Context
        {
            public Context(StateBase state)
            {
                State = state;
                Console.WriteLine("Créer un objet de la classe de contexte avec l'état initial ..");
            }
            public StateBase State { get; set; }

            /// <summary>
            /// State change request
            /// </summary>
            public void Request()
            {
                State.Change(this);
            }
        }
    }
}
