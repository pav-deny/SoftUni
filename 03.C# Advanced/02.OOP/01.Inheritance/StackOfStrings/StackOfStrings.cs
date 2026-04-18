namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count <= 0)
                return true;

            return false;
        }

        public void AddRange(Stack<string> stack)
        {
            foreach (string item in stack) 
                this.Push(item);
        }
    }
}
