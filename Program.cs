using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yousource_Project
{
    class Program
    {
        static void Main()
        {
            
            Context c = new Context(new ConcreteStateA());

           
            c.Request();
            c.Request();
            c.Request();
            c.Request();

           
            Console.ReadKey();
        }
    }

   
    abstract class State
    {
        public abstract void Handle(Context context);
    }

   
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

   
    class Context
    {
        private State _state;

       
        public Context(State state)
        {
            this.State = state;
        }

       
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " +
                  _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}
