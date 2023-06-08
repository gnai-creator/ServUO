namespace Server.Items
{
    [Flipable(0x48BC, 0x48BD)]
    public class TrainingGargishKryss : BaseSword
    {
        [Constructable]
        public TrainingGargishKryss()
            : base(0x48BC)
        {
            Weight = 2.0;
	    Hue = 656;
	    Name = "A Training Gargish Kryss";
	    WeaponAttributes.SelfRepair = 5;
        LootType = LootType.Blessed;
	    Attributes.SpellChanneling = 1;

        }

        public TrainingGargishKryss(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
        public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;
        public override int StrengthReq => 10;
        public override int MinDamage => 8;
        public override int MaxDamage => 10;
        public override float Speed => 2.00f;

        public override int DefHitSound => 0x23C;
        public override int DefMissSound => 0x238;
        public override int InitMinHits => 255;
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
