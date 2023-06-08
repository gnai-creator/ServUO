using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class TrainingWeaponsHumans : Bag 
   { 
		[Constructable] 
		public TrainingWeaponsHumans() : this( 1 ) 
		{ 		
			Movable = true;  
			Name = "Human training gear";
			Hue = 1161;
		}
		[Constructable]
		public TrainingWeaponsHumans( int amount )
		{
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			DropItem( new TrainingKryss() );
			//NEXT TRAINING WEAPON
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			DropItem( new TrainingKatana() );
			//NEXT TRAINING WEAPON
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			DropItem( new TrainingMace() );
			//NEXT TRAINING WEAPON
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			DropItem( new TrainingShield() );
			//NEXT TRAINING WEAPON
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			DropItem( new TrainingQuiver() );
			//NEXT TRAINING WEAPON
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
			DropItem( new TrainingBow() );
		}

      public TrainingWeaponsHumans( Serial serial ) : base( serial ) 
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
      } 
   } 
} 
