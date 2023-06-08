namespace Server.Items
{
    public class TrainingGargishBoomerang : BaseThrown
    {
        [Constructable]
        public TrainingGargishBoomerang()
            : base(0x8FF)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
	    Hue = 656;
        LootType = LootType.Blessed;
	    Name = "A Training Boomerang";
	    WeaponAttributes.SelfRepair = 5;
	    Attributes.SpellChanneling = 1;
        }

        public TrainingGargishBoomerang(Serial serial)
            : base(serial)
        {
        }

        public override int MinThrowRange => 4;

        public override WeaponAbility PrimaryAbility => WeaponAbility.MysticArc;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
        public override int StrengthReq => 10;
        public override int MinDamage => 10;
        public override int MaxDamage => 12;
        public override float Speed => 2.75f;

        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
