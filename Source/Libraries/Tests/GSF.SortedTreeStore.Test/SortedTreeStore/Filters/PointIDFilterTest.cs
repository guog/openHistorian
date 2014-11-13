﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSF.IO.Unmanaged;
using NUnit.Framework;
using openHistorian.Collections;

namespace GSF.Snap.Filters.Test
{
    [TestFixture]
    public class PointIDFilterTest
    {
        [Test]
        public void TestBitArray()
        {
            var list = new List<ulong>();
            var pointId = PointIdMatchFilter.CreateFromList<HistorianKey, HistorianValue>(list);

            if (!pointId.GetType().FullName.Contains("BitArrayFilter"))
                throw new Exception("Wrong type");

            using (var bs = new BinaryStream(allocatesOwnMemory: true))
            {
                bs.Write(pointId.FilterType);
                pointId.Save(bs);
                bs.Position = 0;

                var filter = Library.Filters.GetMatchFilter<HistorianKey, HistorianValue>(bs.ReadGuid(), bs);

                if (!filter.GetType().FullName.Contains("BitArrayFilter"))
                    throw new Exception("Wrong type");
            }
        }

        [Test]
        public void TestUintHashSet()
        {
            var list = new List<ulong>();
            list.Add(132412341);
            var pointId = PointIdMatchFilter.CreateFromList<HistorianKey, HistorianValue>(list);

            if (!pointId.GetType().FullName.Contains("UIntHashSet"))
                throw new Exception("Wrong type");

            using (var bs = new BinaryStream(allocatesOwnMemory: true))
            {
                bs.Write(pointId.FilterType);
                pointId.Save(bs);
                bs.Position = 0;

                var filter = Library.Filters.GetMatchFilter<HistorianKey, HistorianValue>(bs.ReadGuid(), bs);

                if (!filter.GetType().FullName.Contains("UIntHashSet"))
                    throw new Exception("Wrong type");
            }
        }

        [Test]
        public void TestUlongHashSet()
        {
            var list = new List<ulong>();
            list.Add(13242345234523412341ul);
            var pointId = PointIdMatchFilter.CreateFromList<HistorianKey, HistorianValue>(list);

            if (!pointId.GetType().FullName.Contains("ULongHashSet"))
                throw new Exception("Wrong type");

            using (var bs = new BinaryStream(allocatesOwnMemory: true))
            {
                bs.Write(pointId.FilterType);
                pointId.Save(bs);
                bs.Position = 0;

                var filter = Library.Filters.GetMatchFilter<HistorianKey, HistorianValue>(bs.ReadGuid(), bs);

                if (!filter.GetType().FullName.Contains("ULongHashSet"))
                    throw new Exception("Wrong type");
            }
        }

    }
}
