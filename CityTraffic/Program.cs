using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
// test 



class MainClass
{

    public static string CityTraffic(string[] strArr)
    {

        // code goes here  
        string maxtraffics = string.Empty;
        string firstNode = string.Empty;
        int NrOfCities = strArr.Length;
        int Node;
        string[] neighbors;
      

        // go thew all nodes (Cities) in the graph
        for (int i = 0; i < NrOfCities; i++)
        {
             // find Node and neighbores for this
            Node = Int32.Parse(strArr[i].ToCharArray().ElementAt(0).ToString());
            neighbors = findNeighbors(Node, strArr);
            int neighborsTraffic = GetNeighborsTraffic(Node, neighbors, strArr);
            if (i == NrOfCities - 1)
                maxtraffics += Node.ToString() + ":" + neighborsTraffic.ToString();
            else
           maxtraffics += Node.ToString() + ":" + neighborsTraffic.ToString() + ",";
        }
        // to do sort
       // var listofstr = maxtraffics.Split(',');
       // listofstr = listofstr.OrderBy(x => x.ToCharArray().ElementAt(0));
        //string str = listofstr.OrderBy(x => x.ToCharArray().ElementAt(0)).ToString();
        return maxtraffics;

    }

    // returns neighbor of a node in the strArr.
    public static string[] findNeighbors(int node, string[] strArr)
    {
        string[] neighbors = null;
        for (int i = 0; i < strArr.Length; i++)
            if (strArr[i].Contains(node.ToString() + ":"))
            {
                string tempstr = strArr[i].Substring(2).Replace(":", "").Replace("[", "").Replace("]", "");
                neighbors = tempstr.Split(',');
                return neighbors;
            }
        return neighbors;
    }

    // get max traffic for neighbors of a node (city)
    public static int GetNeighborsTraffic(int node, string[] neighbors, string[] strArr)
    {
        int NeighborsTr = 0;
        string[] tNeighbors = null;

        for (int j = 0; j < neighbors.Length; j++)
        {
            int tNode = Int32.Parse(neighbors[j]);
            //find number of tNode
            tNeighbors = findNeighbors(tNode, strArr);
            //if node exist in the neighbors remove node from the list.
            var list = new List<string>(tNeighbors);
            list.Remove(node.ToString());
            tNeighbors = list.ToArray();
            //Get traffic from this node (city).
            NeighborsTr += System.Math.Max(tNode, GetNeighborsTraffic(tNode, tNeighbors, strArr));  // gives stack overflow
        }
            return NeighborsTr;
    }

    public static int getMaxtraffic(int j, string[] strAr)
    {
        int maxtr = 0;
        int NrOfCities = strAr.Length;

        string CityAndpop;

        string[] CityNeighbors;

        //find j+ ":" in the strArr
        for (int k = 0; k < NrOfCities; k++)
        {
            if (strAr[k].Contains(j.ToString() + ":"))
            {
                CityAndpop = strAr[k];
                CityNeighbors = new[] { CityAndpop.Substring(2) };
                string tempstr = CityAndpop.Substring(2).Replace("[", "").Replace("]", "");
                CityNeighbors = tempstr.Split(",");
                for (int kk = 0; kk < CityNeighbors.Length; kk++)
                {
                    int node = Int32.Parse(string.Join("", CityNeighbors[kk]));
                    maxtr += System.Math.Max(node, getMaxtraffic(node, strAr));
                }
            }
        }
        return maxtr;
    }




  
    static void Main()
            {
                // keep this function call here
                string[] stingArray = {"1:[5]", "4:[5]", "3:[5]", "5:[1,4,3,2]", "2:[5,15,7]", "7:[2,8]", "8:[7,38]", "15:[2]", "38:[8]"};
        // Console.WriteLine(CityTraffic(Console.ReadLine()));
        Console.WriteLine(CityTraffic(stingArray));

        // out put should be: 1:82,2:53,3:80,4:79,5:70,7:46,8:38,15:68,38:45.
    }

}
