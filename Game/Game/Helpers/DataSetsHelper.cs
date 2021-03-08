﻿using System;
using System.Threading.Tasks;

using Game.ViewModels;

namespace Game.Helpers
{
    /// <summary>
    /// Helper for Data Sets 
    /// </summary>
    static public class DataSetsHelper
    {
        /// <summary>
        /// Warmup for data sets 
        /// </summary>
        /// <returns></returns>
        static public bool WarmUp()
        {
            ScoreIndexViewModel.Instance.GetCurrentDataSource();
            ItemIndexViewModel.Instance.GetCurrentDataSource();
            CellIndexViewModel.Instance.GetCurrentDataSource();
            MonsterIndexViewModel.Instance.GetCurrentDataSource();

            return true;
        }

        // Readonly wipelock object 
        private static readonly object WipeLock = new object();

        /// <summary>
        /// Call the Wipe routines in order one by one
        /// </summary>
        /// <returns></returns>
        static public async Task<bool> WipeDataInSequence()
        {
            lock (WipeLock)
            {
                var runSyncScore = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await ScoreIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncScore.Wait();
                

                var runSyncItem = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await ItemIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncItem.Wait();

                //var runSyncCharacter = Task.Factory.StartNew(new Func<Task>(async () =>
                //{
                //    await CharacterIndexViewModel.Instance.DataStoreWipeDataListAsync();
                //    await Task.Delay(100);
                //})).Unwrap();

                //var runSyncMonster = Task.Factory.StartNew(new Func<Task>(async () =>
                //{
                //    await MonsterIndexViewModel.Instance.DataStoreWipeDataListAsync();
                //    await Task.Delay(100);
                //})).Unwrap();
                //runSyncCharacter.Wait();
            }

            return await Task.FromResult(true);
        }
    }
}