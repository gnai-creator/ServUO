namespace Server.Items
{
    [Flipable(0x48C2, 0x48C3)]
    public class TrainingGargishMaul : BaseBashing
    {
        [Constructable]
        public TrainingGargishMaul()
            : base(0x48C2)
        { 
	    Hue = 656;
	    Name = "A Training Gargish Maul";
	    WeaponAttributes.SelfRepair = 5;
	    Attributes.SpellChanneling = 1;
        LootType = LootType.Blessed;
	    Weight = 5.0;
        }

        public TrainingGargishMaul(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
        public override int StrengthReq => 10;
        public override int MinDamage => 8;
        public override int MaxDamage => 16;
        public override float Speed => 3.50f;

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
