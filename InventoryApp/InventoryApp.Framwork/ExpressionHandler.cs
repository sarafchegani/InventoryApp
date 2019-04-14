using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Framwork
{
    public class ExpressionHandler : ExpressionVisitor
    {
        List<string> propertyName = new List<string>();
        public string GetPropertyName(Expression exp)
        {
            propertyName.Clear();
            Visit(exp);
            propertyName.Reverse();
            return string.Join(".", propertyName);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            propertyName.Add(node.Member.Name);
            return base.VisitMember(node);
        }
    }
}
