// 232. Implement Queue using Stacks
// Tags: quirky, stack
//

public class MyQueue 
{
    private Stack<int> ins;
    private Stack<int> outs;
    
    public MyQueue() 
    {
        ins = new();
        outs = new();
    }
    
    public void Push(int x) 
    {
        ins.Push(x);
    }
    
    public int Pop() 
    {
        this.Peek();
        return outs.Pop();
    }
    
    public int Peek() 
    {
        if(outs.Count == 0)
        {
            while(ins.Count > 0)
            {
                outs.Push(ins.Pop());
            }
        }
        return outs.Peek();
    }
    
    public bool Empty() 
    {
        if(ins.Count == 0 && outs.Count == 0)
            return true;
        else
            return false;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */