using DataStructures.BasicStructures;

namespace Tasks._2._1_BracketsCheck
{
    public class BracketsChecker
    {
        public string CheckToString(string input)
        {
            var res = Check(input);
            return res == 0 ? "Success" : res.ToString();
        }

        public int Check(string input)
        {
            BasicStack<char> stack = new BasicStack<char>();
            BasicStack<int> stackIndex = new BasicStack<int>();

            int index = 0;
            foreach (var ch in input)
            {
                index++;
                //if (!"{}[]()".Contains(ch)) continue;
                if (!(ch.Equals('[') || ch.Equals(']') ||
                    ch.Equals('(') || ch.Equals(')') ||
                    ch.Equals('{') || ch.Equals('}'))) continue;
                stackIndex.Push(index);
                if (ch.Equals('[')
                    || ch.Equals('(')
                    || ch.Equals('{'))
                {
                    stack.Push(ch);
                    continue;
                }
                else
                {
                    if (stack.Count == 0) return stackIndex.Pop();
                    var top = stack.Pop();
                    if (
                        (top == '[' && ch != ']')
                        || (top == '(' && ch != ')')
                        || (top == '{' && ch != '}'))
                        return stackIndex.Pop();
                    stackIndex.Pop();
                    stackIndex.Pop();
                }
            }
            if (stack.Count != 0) return stackIndex.Pop(); // index;
            return 0;
        }
    }
}
