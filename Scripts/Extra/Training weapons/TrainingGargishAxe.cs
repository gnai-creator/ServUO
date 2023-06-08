namespace Server.Items
{
    [Flipable(0x48B2, 0x48B3)]
    public class TrainingGargishAxe : BaseAxe
    {
        [Constructable]
        public TrainingGargishAxe()
            : base(0x48B2)
        {
            Weight = 4.0;
 	    Hue = 656;
        LootType = LootType.Blessed;
	    Name = "A Training Gargish Axe";
	    WeaponAttributes.SelfRepair = 5;
	    Attributes.SpellChanneling = 1;

        }

        public TrainingGargishAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;
        public override int StrengthReq => 10;
        public override int MinDamage => 12;
        public override int MaxDamage => 15;
        public override float Speed => 3.00f;

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
