using System;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class TrainingBow : BaseRanged
    {
        [Constructable]
        public TrainingBow()
            : base(0x13B2)
        {
            Weight = 10.0;
            Layer = Layer.TwoHanded;
            LootType = LootType.Blessed;
			Hue = 1161;
			Name = "A Training Bow";
			WeaponAttributes.SelfRepair = 3;
			Attributes.SpellChanneling = 1;
        }

        public TrainingBow(Serial serial)
            : base(serial)
        {
        }

	public override int EffectID => 0xF42;
        public override Type AmmoType => typeof(Arrow);
        public override Item Ammo => new Arrow();
        public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int StrengthReq => 10;
        public override int MinDamage => 15;
        public override int MaxDamage => 20;
        public override float Speed => 2.00f;

        public override int DefMaxRange => 10;
        public override int InitMinHits => 250;
        public override int InitMaxHits => 255;
        public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;
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
