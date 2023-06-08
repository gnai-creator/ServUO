using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(DiscMace))]
    [FlipableAttribute(0xF5C, 0xF5D)]
    public class TrainingMace : BaseBashing
    {
        [Constructable]
        public TrainingMace()
            : base(0xF5C)
        {
            Weight = 14.0;
			Hue = 1161;
			Name = "A Training Mace";
            LootType = LootType.Blessed;
			WeaponAttributes.SelfRepair = 5;
			Attributes.SpellChanneling = 1;
        }

        public TrainingMace(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;
        public override int StrengthReq => 10;
        public override int MinDamage => 10;
        public override int MaxDamage => 13;
        public override float Speed => 2.00f;

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