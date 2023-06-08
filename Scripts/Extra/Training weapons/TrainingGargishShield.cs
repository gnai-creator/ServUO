namespace Server.Items
{
    [Flipable(0x422A, 0x422C)]
    public class TrainingGargishShield : BaseShield
    {
        [Constructable]
        public TrainingGargishShield()
            : base(0x422A)
        {
        Name = "A Training Gargish Shield";   
        Hue = 656;      
	    Weight = 2.0;
	    WeaponAttributes.SelfRepair = 5;
	    PhysicalBonus = 3;
	    FireBonus = 1;
	    ColdBonus = 2;
	    PoisonBonus = 2;
	    EnergyBonus = 2;	
   	    Attributes.SpellChanneling = 1;
        LootType = LootType.Blessed;
        }

        public TrainingGargishShield(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 1;
        public override int BaseFireResistance => 0;
        public override int BaseColdResistance => 0;
        public override int BasePoisonResistance => 0;
        public override int BaseEnergyResistance => 0;
        public override int InitMinHits => 255;
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
            writer.Write(0); //version
        }
    }
}
