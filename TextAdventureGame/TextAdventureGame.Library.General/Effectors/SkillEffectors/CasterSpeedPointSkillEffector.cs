﻿using MsgPack.Serialization;
using System.Collections.Generic;

namespace TextAdventureGame.Library.General.Effectors.SkillEffectors
{
    public class CasterSpeedPointSkillEffector : SustainSkillEffector
    {
        [MessagePackMember(id: 1, Name = "SpeedPoint")]
        public int SpeedPoint { get; private set; }

        public override string Information
        {
            get
            {
                if (SpeedPoint > 0)
                    return string.Format("施放者速度提升{0}點{1}回合", SpeedPoint, SustainRound);
                else
                    return string.Format("施放者速度下降{0}點{1}回合", -SpeedPoint, SustainRound);
            }
        }

        public CasterSpeedPointSkillEffector() { }
        public CasterSpeedPointSkillEffector(int sustainRound, int speedPoint) : base(sustainRound)
        {
            SpeedPoint = speedPoint;
        }

        public override void Use(BattleFactors casterFactors, List<BattleFactors> targetsFactors)
        {
            casterFactors.speedPoint += SpeedPoint;
        }
        public override void End(BattleFactors affectedBF)
        {
            affectedBF.speedPoint -= SpeedPoint;
        }
    }
}
