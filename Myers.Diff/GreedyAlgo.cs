using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myers.Diff
{
    public class GreedyAlgo
    {
        public Vertex[] Start(string a, string b)
        {
            int N = a.Length;
            int M = b.Length;

            int MAX = N + M;
            
            var V = new SArray<int>(MAX * 2, -MAX);//NegArray added to allow for negative array to mirror the original form
            List<Vertex> vertices = new List<Vertex>();

            for (int D = 0; D <= MAX; D++)
            {
                Console.WriteLine($"D={D}");

                for (int k = -D; k <= D; k += 2)
                {
                    int x = 1;
                    Console.WriteLine($"\tk={k}");

                    if (k == -D ||                      //k == -D on every first iteration of k i.e for(int k=-D ... )
                        k != D && V[k - 1] < V[k + 1])  //after the first iteration, if the move down is less than the move to the right
                    {
                        x = V[k + 1]; //move right
                    }
                    else
                    {
                        x = V[k - 1] + 1; //move down
                    }

                    int y = Math.Abs(x - k);

                    int i = x - 1; //i,j inserted to align a and b (0 indexed) to match the original form that uses lower bound 1 index
                    int j = y - 1;

                    while (x < N && y < M && a[i + 1] == b[j + 1])//if it a and b is a match, move diagonally i.e x+1,y+1
                    {
                        Console.WriteLine($"\t\ta[{i + 1}]={a[i + 1]},b[{j + 1}]={b[j + 1]}");//this is also where we save the D-path
                        vertices.Add(new Vertex(D, a[i + 1], x, y));
                        x++;
                        y++;

                        i = x - 1;
                        j = y - 1;
                    }

                    V[k] = x;//set the next x into k (note: k line in steps of 2, next line will be 2 lines away)

                    if (x >= N && y >= M)//this means that x and 7 have exceeded the edit graph
                    {
                        return vertices.ToArray();
                    }
                }
            }

            return vertices.ToArray();
        }
    }
}
