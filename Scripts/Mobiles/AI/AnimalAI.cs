using Server.Utilities;

namespace Server.Mobiles
{
    public class AnimalAI : BaseAI
    {
        public AnimalAI(BaseCreature m)
            : base(m)
        { }

        public override bool DoActionWander()
        {
            m_Mobile.DebugSay("I have no combatant");
			m_Mobile.Lifespan -= 1;
			if (m_Mobile.Lifespan <= 0 && m_Mobile.LastOwner == null && !m_Mobile.Summoned)
			{
				//m_Mobile.Lifespan = m_Mobile.DefaultLifeSpan;
				m_Mobile.Kill();
			}
			if (m_Mobile.m_Gender == null)
			{
				m_Mobile.m_Gender = Utility.Random(10) > 5 ? "male" : "female";
			}

			if (m_Mobile.Alive && !m_Mobile.m_Pregmant && m_Mobile.m_Gender != "male" && m_Mobile.LastOwner == null)
			{
				var map = m_Mobile.Map;
				var eable = map.GetMobilesInRange(m_Mobile.Location, m_Mobile.RangePerception);

				foreach (var m in eable)
				{
					if (m is BaseCreature)
					{
						var creature = m as BaseCreature;
						if (creature.AIObject != null)
						{
							if (creature.m_Gender == "male" && !m_Mobile.m_Pregmant && creature.Body == m_Mobile.Body && Utility.Random(100) > 30)
							{
								MoveTo(creature, true, 1);
								creature.PlaySound(creature.GetDeathSound());
								m_Mobile.m_Pregmant = true;
								m_Mobile.PregCounter = 0;
								break;
							}
						}


					}
				}
			}

			if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false))
            {
                m_Mobile.DebugSay("I have detected {0}, attacking", m_Mobile.FocusMob.Name);

                m_Mobile.Combatant = m_Mobile.FocusMob;
                Action = ActionType.Combat;
            }
			else if (m_Mobile.m_Pregmant)
			{
				m_Mobile.PregCounter++;

				if (m_Mobile.PregCounter > m_Mobile.PregTimeLimit)
				{
					m_Mobile.PublicEmote("*It is going to born*", 0x04b9);
					m_Mobile.m_Pregmant = false;
					var son = m_Mobile.GetType().CreateInstance<BaseCreature>();
					son.MoveToWorld(m_Mobile.Location, m_Mobile.Map);
					m_Mobile.PregCounter = 0;
				}
				else
				{
					base.DoActionWander();
				}
			}
			else
            {

                base.DoActionWander();
            }

            return true;
        }

        public override bool DoActionCombat()
        {
            IDamageable c = m_Mobile.Combatant;

            if (c == null || c.Deleted || c.Map != m_Mobile.Map || !c.Alive || (c is Mobile && ((Mobile)c).IsDeadBondedPet))
            {
                m_Mobile.DebugSay("My combatant is gone, so my guard is up");

                Action = ActionType.Guard;

                return true;
            }

            if (!m_Mobile.InRange(c, m_Mobile.RangePerception))
            {
                // They are somewhat far away, can we find something else?
                if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false))
                {
                    m_Mobile.Combatant = m_Mobile.FocusMob;
                    m_Mobile.FocusMob = null;
                }
                else if (!m_Mobile.InRange(c, m_Mobile.RangePerception * 3))
                {
                    m_Mobile.Combatant = null;
                }

                c = m_Mobile.Combatant;

                if (c == null)
                {
                    m_Mobile.DebugSay("My combatant has fled, so I am on guard");
                    Action = ActionType.Guard;

                    return true;
                }
            }

            if (MoveTo(c, true, m_Mobile.RangeFight))
            {
                if (!DirectionLocked)
                    m_Mobile.Direction = m_Mobile.GetDirectionTo(c);
            }
            else if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false))
            {
                m_Mobile.DebugSay("My move is blocked, so I am going to attack {0}", m_Mobile.FocusMob.Name);

                m_Mobile.Combatant = m_Mobile.FocusMob;
                Action = ActionType.Combat;

                return true;
            }
            else if (m_Mobile.GetDistanceToSqrt(c) > m_Mobile.RangePerception + 1)
            {
                m_Mobile.DebugSay("I cannot find {0}, so my guard is up", c.Name);

                Action = ActionType.Guard;

                return true;
            }
            else
            {
                m_Mobile.DebugSay("I should be closer to {0}", c.Name);
            }

            if (!m_Mobile.Controlled && !m_Mobile.Summoned && m_Mobile.CheckCanFlee())
            {
                m_Mobile.DebugSay("I am going to flee from {0}", c.Name);
                Action = ActionType.Flee;
            }

            return true;
        }

        public override bool DoActionGuard()
        {
            if (AcquireFocusMob(m_Mobile.RangePerception, m_Mobile.FightMode, false))
            {
                m_Mobile.DebugSay("I have detected {0}, attacking", m_Mobile.FocusMob.Name);

                m_Mobile.Combatant = m_Mobile.FocusMob;
                Action = ActionType.Combat;
            }
            else
            {
                base.DoActionGuard();
            }

            return true;
        }

        public override bool DoActionFlee()
        {
            Mobile c = m_Mobile.Combatant as Mobile;

            if (m_Mobile.CheckBreakFlee())
            {
                // If I have a target, go back and fight them
                if (c != null && m_Mobile.GetDistanceToSqrt(c) <= m_Mobile.RangePerception * 2)
                {
                    m_Mobile.DebugSay("I am stronger now, reengaging {0}", c.Name);
                    Action = ActionType.Combat;
                }
                else
                {
                    m_Mobile.DebugSay("I am stronger now, my guard is up");
                    Action = ActionType.Guard;
                }
            }
            else
            {
                base.DoActionFlee();
            }

            return true;
        }
    }
}
