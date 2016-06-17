using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLab.AOP
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodPerformanceAttribute:Attribute
    {
        public virtual string OnMethodExecuting()
        {
            return "Method is executing...";
        }

        public virtual string OnMethodExecuted()
        {
            return "Method executed.";
        }
    }
}
