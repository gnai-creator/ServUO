using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishWoodenShield))]
    public class TrainingShield : BaseShield
    {
      
	[Constructable]
        public TrainingShield()
            : base(0x1B72)
        {
            	Weight = 10.0;
		Name = "A Training shield";
		Hue = 1161;
        Attributes.SpellChanneling = 1;
		ArmorAttributes.LowerStatReq = 100;
		WeaponAttributes.SelfRepair = 10;
        LootType = LootType.Blessed;

        }

        public TrainingShield(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 3;
        public override int BaseFireResistance => 2;
        public override int InitMinHits => 250;
        public override int InitMaxHits => 255;
        public override int StrReq => 10;
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);//version
        }
    }
}