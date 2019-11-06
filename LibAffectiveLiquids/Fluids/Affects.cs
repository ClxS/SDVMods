namespace LibAffectiveFluids.Fluids
{
    using System;

    [Flags]
    public enum Affects
    {
        HostPlayer         = 0b0000000001,
        NetworkPlayer      = 0b0000000010,
        Npcs               = 0b0000000100,
        Monsters           = 0b0000001000,
        AllPlayers = HostPlayer | NetworkPlayer,
        AllPlayersAndMonsters = AllPlayers | Monsters,
        Everything = AllPlayersAndMonsters | Npcs
    }
}