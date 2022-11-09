// 901. Online Stock Span
// Tags: stack, monotonic stack
//

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
public class StockSpanner 
{
    private Stack<(int price, int span)> _stocks { get; set; }

    // Optimization
    private int _prevVal { get; set; }

    public StockSpanner() 
    {
        _stocks = new();
        _prevVal = int.MaxValue;
    }
    
    public int Next(int price) 
    {
        int newSpan = 1;

        if(_prevVal > price)
        {
            _stocks.Push((price, 1));
        }

        else // _prevVal <= price
        {
            while(_stocks.Peek().price <= price)
            {
                (int price, int span) ps = _stocks.Pop();
                newSpan += ps.span;

                // Break out early if the stack is empty.
                if(_stocks.Count == 0)
                    break;
            }
            _stocks.Push((price, newSpan));
        }

        _prevVal = price;
        return newSpan;
    }
}
