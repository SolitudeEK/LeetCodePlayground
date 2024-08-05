namespace LeetCodePlayground
{
    /// <summary>
    /// The class for problem 2751. Robot Collisions.
    /// </summary>
    public class RobotCollison
    {
        public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            int n = positions.Length;
            var robots = new List<Robot>();

            for (int i = 0; i < n; i++)
                robots.Add(new Robot(healths[i], positions[i], directions[i], i));

            robots = robots.OrderBy(robot => robot.Position).ToList();

            Stack<Robot> stack = new Stack<Robot>();

            foreach (var robot in robots)
            {
                if (robot.Direction == 'R')
                    stack.Push(robot);
                else
                {
                    while (stack.Count > 0 && stack.Peek().Direction == 'R' && stack.Peek().Health < robot.Health)
                    {
                        stack.Pop();
                        robot.Health--;
                    }

                    if (stack.Count > 0 && stack.Peek().Direction == 'R' && stack.Peek().Health == robot.Health)
                    {
                        stack.Pop();
                        robot.Health = 0;
                    }
                    else if (stack.Count > 0 && stack.Peek().Direction == 'R' && stack.Peek().Health > robot.Health)
                    {
                        var robotR = stack.Pop();
                        robotR.Health--;
                        stack.Push(robotR);
                        robot.Health = 0;
                    }

                    if (robot.Health > 0)
                        stack.Push(robot);
                }
            }

            return stack.ToList().OrderBy(x => x.Index).Select(x => x.Health).ToList(); 
        }
    }
    public class Robot 
    {
       public int Position { get; set; }
       public int Health { get; set; }
       public char Direction { get; set; }
       public int Index { get; set; }

        public Robot(int health, int position, char direction, int index)
        {
            Position = position;
            Health = health;
            Direction = direction;
            Index = index;
        }
    }

}
