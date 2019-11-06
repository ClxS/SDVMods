namespace LibArcanium.Magic
{
    using System;

    [Flags]
    public enum ManaType
    {               
        // Trivial Types
        Grey            = 0b000000000000001,
        Air             = 0b000000000000010,
        Fire            = 0b000000000000100,
        Earth           = 0b000000000001000,
        Water           = 0b000000000010000,
        Umbral          = 0b000000000100000,
        Light           = 0b000000001000000,
        Life            = 0b000000010000000,
        Death           = 0b000000100000000,
        Mental          = 0b000001000000000,
        Perception      = 0b000010000000000,
        Transference    = 0b000100000000000,
        Enhancement     = 0b001000000000000,

        // Composite Types
        Lightning = Air | Fire,
        Sand = Earth | Water,
        Ice = Water | Air,
        Metal = Fire | Earth
    }

    public static class ManaTypeExtensions
    {
        public static ManaType? GetOpposite(this ManaType @this)
        {
            switch (@this)
            {
                case ManaType.Metal:
                case ManaType.Ice:
                case ManaType.Grey:
                    return null;
                case ManaType.Lightning:
                    return ManaType.Sand;
                case ManaType.Sand:
                    return ManaType.Light;
                case ManaType.Air:
                    return ManaType.Earth;
                case ManaType.Fire:
                    return ManaType.Water;
                case ManaType.Earth:
                    return ManaType.Air;
                case ManaType.Water:
                    return ManaType.Fire;
                case ManaType.Umbral:
                    return ManaType.Light;
                case ManaType.Light:
                    return ManaType.Umbral;
                case ManaType.Life:
                    return ManaType.Death;
                case ManaType.Death:
                    return ManaType.Life;
                case ManaType.Mental:
                    return ManaType.Perception;
                case ManaType.Perception:
                    return ManaType.Mental;
                case ManaType.Transference:
                    return ManaType.Enhancement;
                case ManaType.Enhancement:
                    return ManaType.Transference;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@this), @this, null);
            }
        }
    }
}