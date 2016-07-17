using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _639A
{
    class Program
    {
        static void Main(string[] args)
        {
            string numOfArgs = Console.ReadLine();
            int numOfFriends, sizeOfWindow, numOfCommands;
            getNumOfArguments(numOfArgs, out numOfFriends, out sizeOfWindow, out numOfCommands);
            Friends.WindowCapacity = sizeOfWindow;
            Friends.FriendsInWindow = new List<Friend>();
            string friendLevelsStr = Console.ReadLine();
            int[] friendsLevel = friendLevelsStr.Split(' ').Select(x => Int32.Parse(x)).ToArray();
            Command[] commands = new Command[numOfCommands];
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = CreateCommand(Console.ReadLine(), friendsLevel);
            }
            foreach (Command command in commands)
            {
                command.Execute();
            }
            Console.ReadKey();
        }

        private static Command CreateCommand(string commandString, int[] friendsLevel)
        {
            int friendId = int.Parse(commandString.Split(' ')[1]) - 1;
            if (commandString[0] == '1')
                return new OnlineCommand(friendId, friendsLevel[friendId]);
            else
                return new CheckWindowCommand(friendId, friendsLevel[friendId]);
        }

        private static void getNumOfArguments(string input, out int numOfFriends, out int sizeOfWindow, out int numOfCommands)
        {
            string[] inputsArr = input.Split(' ');
            numOfFriends = Int32.Parse(inputsArr[0]);
            sizeOfWindow = Int32.Parse(inputsArr[1]);
            numOfCommands = Int32.Parse(inputsArr[2]);
        }
    }

    public static class Friends
    {
        public static int WindowCapacity { get; set; }
        public static List<Friend> FriendsInWindow { get; set; }
        public static void FriendOnline(Friend friend)
        {
            if (FriendsInWindow.Count == 0)
                FillWindow();
            int windowSize = FriendsInWindow.Count;
            for (int i = 0; i < windowSize; i++)
            {
                if (FriendsInWindow[i].Level < friend.Level)
                {
                    FriendsInWindow.Insert(i, friend);
                    FriendsInWindow.RemoveAt(windowSize);
                    break;
                }
            }
        }

        private static void FillWindow()
        {
            for (int i = 0; i < WindowCapacity; i++)
                FriendsInWindow.Add(new Friend() { Id = -1, Level = -1 });
        }

        public static bool IsFriendOnline(Friend friend)
        {
            foreach (Friend friendInWindow in FriendsInWindow)
            {
                if (friendInWindow.Id == friend.Id)
                    return true;
            }
            return false;
        }
    }

    public class Friend
    {
        public int Id { get; set; }
        public int Level { get; set; }
    }

    abstract class Command
    {
        public Command(int id, int level)
        {
            Friend = new Friend() { Id = id, Level = level };
        }
        public Friend Friend { get; set; }
        public abstract void Execute();
    }

    class OnlineCommand : Command
    {
        public OnlineCommand(int id, int level) : base(id, level)
        {
        }

        public override void Execute()
        {
            Friends.FriendOnline(this.Friend);
        }
    }

    class CheckWindowCommand : Command
    {
        public CheckWindowCommand(int id, int level) : base(id, level)
        {
        }

        public override void Execute()
        {
            if (Friends.IsFriendOnline(Friend))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
