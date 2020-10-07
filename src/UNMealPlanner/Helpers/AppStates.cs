using System;
using UNMealPlanner.Types;

namespace UNMealPlanner.Helpers
{
    public class AppStates
    {
        public static ViewType ViewType { get; set; }

        public static Action ViewChanged { get; set; }
    }
}
