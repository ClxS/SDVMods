using StardewValley;
using StardewValley.Monsters;
using System;

namespace LibAffectiveFluids.Utility
{
    public static class TargetHelpers
    {
        public static void HurtEntity(object target, int amount)
        {
            switch(target)
            {
                case Monster monster:
                    int num = Math.Max(1, amount - monster.resilience.Value);
                    if (Game1.random.NextDouble() < monster.missChance.Value)
                    {
                        num = -1;
                    }
                    else
                    {
                        monster.Health = monster.Health - num;
                        try
                        {
                        }
                        catch
                        {
                        }                        
                    }
                    //monster.takeDamage(amount, 0, 0, false, 0.0, "hitEnemy");
                    break;
            }
        }
    }
}