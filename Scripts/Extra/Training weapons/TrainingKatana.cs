using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishKatana))]
    [FlipableAttribute(0x13FF, 0x13FE)]
    public class TrainingKatana : BaseSword
    {
        [Constructable]
        public TrainingKatana()
            : base(0x13FF)
        {
            Weight = 10.0;
			Hue = 1161;
			Name = "A Training Katana";
			WeaponAttributes.SelfRepair = 5;
			Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
        }

        public TrainingKatana(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;
        public override int StrengthReq => 25;
        public override int MinDamage => 10;
        public override int MaxDamage => 12;
        public override float Speed => 2.00f;

        public override int DefHitSound => 0x23B;
        public override int DefMissSound => 0x23A;
        public override int InitMinHits => 250;
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