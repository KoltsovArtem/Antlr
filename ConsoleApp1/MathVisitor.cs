using Antlr4.Runtime.Misc;
using ConsoleApp2;

namespace ConsoleApp3
{
    public class MathVisitor : MathBaseVisitor<int>
    {
        private Dictionary<string, int> memory;

        public MathVisitor(Dictionary<string, int> sharedMemory)
        {
            memory = sharedMemory;
        }

        public override int VisitAssignment([NotNull] MathParser.AssignmentContext context)
        {
            string id = context.ID().GetText();
            int value = Visit(context.expression());
            memory[id] = value;
            return value;
        }

        public override int VisitExpression([NotNull] MathParser.ExpressionContext context)
        {
            if (context.ID() != null)
            {
                string id = context.ID().GetText();
                if (memory.ContainsKey(id))
                    return memory[id];
                return 0; 
            }
            else if (context.INT() != null)
            {
                return int.Parse(context.INT().GetText());
            }
            else if (context.ChildCount == 3)
            {
                if (context.GetChild(0).GetText().Equals("(") && context.GetChild(2).GetText().Equals(")"))
                {
                    return Visit(context.expression(0)); 
                }
                else if (context.GetChild(1).GetText().Equals("*"))
                {
                    return Visit(context.expression(0)) * Visit(context.expression(1));
                }
                else if (context.GetChild(1).GetText().Equals("+"))
                {
                    return Visit(context.expression(0)) + Visit(context.expression(1));
                }
            }
            return VisitChildren(context);
        }

        public override int VisitStart([NotNull] MathParser.StartContext context)
        {
            int? result = null;
            for (int i = 0; i < context.ChildCount; i++)
            {
                result = Visit(context.GetChild(i));
            }
            return result ?? 0;
        }

        public override int VisitStatement([NotNull] MathParser.StatementContext context)
        {
            return Visit(context.GetChild(0));
        }
    }
}
