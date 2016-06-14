using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLab.AOP
{
    //https://social.msdn.microsoft.com/Forums/en-US/7949d8ba-aab9-4045-9027-92c1eae13227/how-to-catchthe-exception-using-attribute-class-in-c-class?forum=csharplanguage
    //http://kb.cnblogs.com/page/94983/
    //http://www.cnblogs.com/ml-virus/p/4127003.html
    //http://blog.csdn.net/jiujiu28/article/details/43602565
    //http://wayfarer.cnblogs.com/wayfarer/articles/256909.html

    /*
     * 常见思路是利用 Proxy 模式，在生成实例前后做AOP处理
     */

    [AttributeUsage(AttributeTargets.Method)]
    class CareExceptionAttribute:Attribute
    {

    }
}
