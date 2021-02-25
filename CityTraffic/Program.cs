using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// inplementation of max traffic for each node (city) in a graph.
/// Example of graph string as input nodes seperated with "-" as following:
///  Input:1:[5]-3:[5]-4:[5]-5:[1,4,3,2]-2:[5,15,7]-7:[2,8]-8:[7,38]-15:[2]-38:[8]
///  Output: Then Output should be: 1:60,2:53,3:60,4:60,5:55,7:46,8:38,15:55,38:32  which is correct.
///  
/// For more description look to the Maximum CityTraffic description.pdf
///  
/// </summary>

class MainClass
{
    static void Main()
    {
       
         Console.WriteLine("Please give a graph string as input seperated with '-': example 1:[5]-5[1]-...");
        string graphStr = Console.ReadLine();
        string[] stingArray = graphStr.Trim().Replace(" ", "").Split('-').ToArray();
        Console.WriteLine();
        Console.WriteLine("Max traffic for each node in the graph as a sorted array is:");
        Console.WriteLine(CityTraffic(stingArray));
    }

    public static string CityTraffic(string[] strArr)
    {
        string maxtraffics = string.Empty;
        int NrOfCities = strArr.Length;
        int Node;
        string[] neighbors;

        try
        {
        // Go thew all nodes (Cities) in the graph and find max trafic for each node according max traffic of neighbors. 
        for (int i = 0; i < NrOfCities; i++)
        {
            // find Node and neighbores for this
            int index = strArr[i].ToString().IndexOf(':');
            Node = Int32.Parse(strArr[i].ToString().Substring(0, index));
            neighbors = findNeighbors(Node, strArr);

            int nodeTraffic = GetMaxNodeTraffic(Node, neighbors, strArr);
            if (i == NrOfCities - 1)
                maxtraffics += Node.ToString() + ":" + nodeTraffic.ToString();
            else
                maxtraffics += Node.ToString() + ":" + nodeTraffic.ToString() + ",";
        }
        // Sort the list.
         var listofstr = maxtraffics.Split(',');
        var sortlistofstr = listofstr.OrderBy(x => Int32.Parse(x.ToString().Split(':')[0])).Distinct().ToList();
        maxtraffics = string.Join(",", sortlistofstr.ToArray());
        }
        catch(Exception ex)
        {
            string msg = ex.Message.ToString();
           Console.WriteLine("Exception from method: CityTraffic, messge: " + msg);
        }

        return maxtraffics;
    }

    // Get max traffic for neighbors of a node (city) in the Graph.
    private static int GetMaxNodeTraffic(int node, string[] neighbors, string[] strArr)
    {
        int maxNodeTraffic = 0;
        string[] tNeighbors = null;
        List<int> lNeTr = new List<int>();
        try
        {
           
        for (int j = 0; j < neighbors.Length; j++)
        {
            int tNode = Int32.Parse(neighbors[j]);
            //Find Neighbors of tNode
            tNeighbors = findNeighbors(tNode, strArr);
            //If node exist in the neighbors remove node from the list.
            var list = new List<string>(tNeighbors);
            list.Remove(node.ToString());
            tNeighbors = list.ToArray();
            maxNodeTraffic = tNode + GetMaxNodeTraffic(tNode, tNeighbors, strArr);
            lNeTr.Add(maxNodeTraffic);
        }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.ToString();
            Console.WriteLine("Exception from method:GetMaxNodeTraffic and message: " + msg);
        }
        if (lNeTr.Count != 0)
            maxNodeTraffic = lNeTr.Max();
        else
            maxNodeTraffic = 0;
     
        return maxNodeTraffic;
    }

    // Finds neighbores of a node from the strArr.
    private static string[] findNeighbors(int node, string[] strArr)
    {
        string[] neighbors = null;
        try
        {
            int nodeLen = node.ToString().Length; // length of node as string.
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].Contains(node.ToString() + ":"))
                {
                    string tempstr = strArr[i].Substring(nodeLen).Replace(":", "").Replace("[", "").Replace("]", "");
                    neighbors = tempstr.Split(',');
                    return neighbors;
                }
            }
        }

        catch (Exception ex)
        {
            string msg = ex.Message.ToString();
            Console.WriteLine("Exception from method: findNeighbors, messge: " + msg);
        }
        return neighbors;
    }


}
