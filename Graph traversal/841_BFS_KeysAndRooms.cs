// 841. Keys and Rooms
// Tags: hash set, BFS
//

public class Solution 
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms) 
    {
        // Edge cases.
        if(!rooms.Any())
            return false;
        else if (!rooms[0].Any())
            return false;

        // Keep track of rooms we already checked.
        HashSet<int> searchedRooms = new();

        // Each integer represents the next room(s) to check.
        Queue<int> queue = new();

        // First-time setup. According to the problem, we start in the 0th room.
        queue.Enqueue(0);

        while(queue.Any())
        {
            for(int i = 0; i < queue.Count; i++)
            {
                int room = queue.Dequeue();
                searchedRooms.Add(room);
                
                // Take all keys in this room and search those next rooms.
                foreach(var key in rooms[room])
                {
                    // If this key belongs to a room we already searched, skip it.
                    if(!searchedRooms.Contains(key))
                        queue.Enqueue(key);
                }
            }
        }

        return searchedRooms.Count == rooms.Count;
    }
}