namespace Server.Items
{
    [Flipable(0x48BA, 0x48BB)]
    public class TrainingGargishKatana : BaseSword
    {
        [Constructable]
        public TrainingGargishKatana()
            : base(0x48BA)
        {
            Weight = 6.0;
        LootType = LootType.Blessed;
	    Hue = 656;
	    Name = "A Training Gargish Katana";
	    WeaponAttributes.SelfRepair = 5;
	    Attributes.SpellChanneling = 1;
        }

        public TrainingGargishKatana(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
        public override int StrengthReq => 10;
        public override int MinDamage => 8;
        public override int MaxDamage => 12;
        public override float Speed => 2.50f;

        public override int DefHitSound => 0x23B;
        public override int DefMissSound => 0x23A;
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
