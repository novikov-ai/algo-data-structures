using System;

namespace StackPostfix
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myTest = new Program();

            Stack<string> stack1 = new Stack<string>();
            stack1.Push("=");
            stack1.Push("+");
            stack1.Push("9");
            stack1.Push("*");
            stack1.Push("5");
            stack1.Push("+");
            stack1.Push("2");
            stack1.Push("8");

            string a = "8 2 + 5*9 +=";
            string b = "1 2 + 3*";

            Console.WriteLine(myTest.Postfix(stack1));
            Console.WriteLine(myTest.Postfix(a));
            Console.WriteLine(myTest.Postfix(b));

            Console.WriteLine(myTest.BalancedBrackets("(((()())((()()))))()"));


            Console.ReadKey();

        }

        public int Postfix(Stack<string> _stack)
        {
            Stack<int> _stack2 = new Stack<int>();

            int result = 0;
            string cache;
            int length = _stack.Size();

            for (int i = 0; i < length; i++)
            {
                switch (cache = _stack.Pop())
                {
                    case "+":
                        {
                            result = _stack2.Pop() + _stack2.Pop();
                            _stack2.Push(result);
                            break;
                        }
                    case "*":
                        {
                            result = _stack2.Pop() * _stack2.Pop();
                            _stack2.Push(result);
                            break;
                        }
                    case "=":
                        {
                            return result;
                        }
                    default:
                        {
                            _stack2.Push(Convert.ToInt32(cache));
                            break;
                        }
                }
            }
            return result;
        }
        public int Postfix(string _sequance)
        {
            Stack<char> _stack1 = new Stack<char>();
            Stack<int> _stack2 = new Stack<int>();

            for (int i=_sequance.Length-1;i>=0;i--)
            {
                if (_sequance[i]!=' ')
                {
                    _stack1.Push(_sequance[i]);
                }
            }

            int result = 0;
            char cache;
            int length = _stack1.Size();

            for (int i = 0; i < length; i++)
            {
                switch (cache = _stack1.Pop())
                {
                    case '+':
                        {
                            result = _stack2.Pop() + _stack2.Pop();
                            _stack2.Push(result);
                            break;
                        }
                    case '*':
                        {
                            result = _stack2.Pop() * _stack2.Pop();
                            _stack2.Push(result);
                            break;
                        }
                    case '=':
                        {
                            return result;
                        }
                    default:
                        {
                            _stack2.Push(Convert.ToInt32(cache.ToString()));
                            break;
                        }
                }
            }
            return result;
        }

        public bool BalancedBrackets(string _value)
        {
            Stack<string> stack1 = new Stack<string>();

            if (_value[0].ToString()==")" || _value[_value.Length-1].ToString()=="(")
            {
                Console.WriteLine("Sequence is not balanced.");
                return false;
            }

            for (int i = 0;i<_value.Length;i++)
            {
                if (_value[i]=='(')
                {
                    stack1.Push(_value[i].ToString());
                }
                else if (_value[i]==')' && stack1.Size()!=0)
                {
                    stack1.Pop();
                }
                else
                {
                    Console.WriteLine("Sequence is not balanced.");
                    return false;
                }
            }
            if (stack1.Size()==0)
            {
                Console.WriteLine("Sequence is balanced.");
                return true;
            }
            Console.WriteLine("Sequence is not balanced.");
            return false;
        }
    }
}
