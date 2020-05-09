using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200423_ExoEntity5.Factories
{
    public abstract class AbstractFactory
    {
        protected AbstractFactory(Random rng)
        {
            _index = 0;
            _rng = rng;
        }

        protected int _index;
        protected Random _rng;

        abstract public Object Create();
    }
}
