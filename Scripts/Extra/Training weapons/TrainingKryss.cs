using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishKryss))]
    [FlipableAttribute(0x1401, 0x1400)]
    public class TrainingKryss : BaseSword
    {
        [Constructable]
        public TrainingKryss()
            : base(0x1401)
        {           
	    Weight = 5.0;
	    Hue = 1161;
	    Name = "A Training Kryss";
	    WeaponAttributes.SelfRepair = 5;
        LootType = LootType.Blessed;
	    Attributes.SpellChanneling = 1;
        }

        public TrainingKryss(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
        public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;
        public override int StrengthReq => 10;
        public override int MinDamage => 9;
        public override int MaxDamage => 11;
        public override float Speed => 2.00f;

        public override int DefHitSound => 0x23C;
        public override int DefMissSound => 0x238;
        public override int InitMinHits => 250;
        public override int InitMaxHits => 255;
        public override SkillName DefSkill => SkillName.Fencing;
        public override WeaponType DefType => WeaponType.Piercing;
        public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;
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