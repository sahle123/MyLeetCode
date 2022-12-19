// 232. Implement Queue using Stacks
// Tags: quirky, stack
//
/**
 * Your MyQueue object will be instantiated and called as such:
 * let obj = MyQueue::new();
 * obj.push(x);
 * let ret_2: i32 = obj.pop();
 * let ret_3: i32 = obj.peek();
 * let ret_4: bool = obj.empty();
 */

struct MyQueue {
    ins: Vec<i32>,
    outs: Vec<i32>,
}


/** 
 * `&self` means the method takes an immutable reference.
 * If you need a mutable reference, change it to `&mut self` instead.
 */
 impl MyQueue {

    fn new() -> Self {
        return MyQueue { ins: Vec::new(), outs: Vec::new(), };
    }
    
    fn push(&mut self, x: i32) {
        self.ins.push(x);
    }
    
    fn pop(&mut self) -> i32 {
        self.peek();

        match self.outs.pop() {
            None => -1,
            Some(n) => (*n),
        }
    }
    
    // Populates the outs stack and returns the top of the
    // outs stack.
    fn peek(&mut self) -> i32 {
        if self.outs.len() == 0 {
            while self.ins.len() > 0 {

                match self.ins.pop() {
                    None => self.outs.push(0),
                    Some(n) => self.outs.push(n),    
                }
            }
        }

        // Return the last element or 0 if it doesn't exist.
        match self.outs.last() {
            None => 0,
            Some(n) => n
        }
    }
    
    fn empty(&self) -> bool {
        if self.ins.is_empty() && self.outs.is_empty() {
            return true;
        }

        false
    }
}