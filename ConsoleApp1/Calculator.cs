using Antlr4.Runtime;
using ConcoleApp3;
using ConsoleApp2;

namespace ConsoleApp3
{
    public static class Calculator
    {
        private static Dictionary<string, int> variables = new Dictionary<string, int>();

        public static int Evaluate(string expression)
        {
            var lexer = new MathLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);

            var parser = new MathParser(tokens);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ThrowExceptionErrorListener());

            var tree = parser.statement();

            var visitor = new MathVisitor(variables);
            return visitor.Visit(tree);
        }
    }
}
