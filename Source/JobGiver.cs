﻿using System;
using UnityEngine;
using Verse;
using Verse.AI;
using RimWorld;

namespace Lab
{
    public class JobGiver_RunningWheelPrisoner : ThinkNode_JobGiver
    {
        public override float GetPriority(Pawn pawn)
        {
            /*
            Need_Food food = pawn.needs.food;
            Need_Rest rest = pawn.needs.rest;
            if (food == null)
            {
                return 0f;
            }
            if ((food.CurLevelPercentage < 0.3f && FoodUtility.ShouldBeFedBySomeone(pawn)))
            {
                return 0f;
            }
            if (rest == null)
            {
                return 0f;
            }
            if((rest.CurLevelPercentage < 0.3f))
            {
                return 0f;
            }*/
            return 0.6f;
        }

        protected override Job TryGiveJob(Pawn pawn)
        {
            //Log.Message("JobGiver_RunningWheelPrisoner.TryGiveJob");
            Map map = pawn.Map;
            //죄수일때만

            if (pawn.IsPrisoner)
            {
                if (pawn.Map.listerThings.ThingsOfDef(ThingDefOf.RK_HamsterWheelGenerator).Any())
                {
                    foreach (Building wheel in pawn.Map.listerThings.ThingsMatching(ThingRequest.ForDef(ThingDefOf.RK_HamsterWheelGenerator)))
                    {
                        if(wheel.Position.IsInPrisonCell(map))
                        {
                            if (pawn.CanReserve(wheel) && wheel.GetComp<CompPowerPlantHamsterWheel>().user == null)
                            {
                                return new Job(JobDefOf.RK_Job_HamsterWheel, wheel);
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
