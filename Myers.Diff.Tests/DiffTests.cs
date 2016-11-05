using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Myers.Diff.Tests
{
    [TestClass]
    public class DiffTests
    {
        [TestMethod]
        public void basic_greedy_algorithm()
        {
            GreedyAlgo algo = new GreedyAlgo();
            var results = algo.Start("ABCABBA", "CBABAC");

            Vertex[] expected = new Vertex[] {
                new Vertex(2,'A',0,2),
                new Vertex(2,'B',1,3),
                new Vertex(2,'B',1,1),
                new Vertex(2,'C',2,0),
                new Vertex(3,'C',2,5),
                new Vertex(3,'A',3,4),
                new Vertex(3,'A',3,2),
                new Vertex(3,'B',4,3),
                new Vertex(3,'B',4,1),
                new Vertex(4,'A',6,4),
                new Vertex(4,'A',6,2)
            };

            for (int x = 0; x < 11; x++)
            {
                Assert.AreEqual(expected[x].D, results[x].D, $"D failed at x={x}");
                Assert.AreEqual(expected[x].C, results[x].C, $"C failed at x={x}");
                Assert.AreEqual(expected[x].X, results[x].X, $"X failed at x={x}");
                Assert.AreEqual(expected[x].Y, results[x].Y, $"Y failed at x={x}");
            }

        }
    }
}
