using System;

namespace AssemblyCSharp
{
	public class Graph<E>
	{
		public int num_nodes;
		public E[] nodes;
		public int[,] adjMat;
		
		public Graph(int num_nodes)
		{
			this.num_nodes = num_nodes;
			nodes = new Object[num_nodes] as E[];
			adjMat = new int[num_nodes,num_nodes];
			
			for (int i = 0; i < this.num_nodes; i++)
			{
				for (int j = 0; j < this.num_nodes; j++)
				{
					adjMat[i, j] = 0;
				}
			}
		}
		
		public int adjacent(int x, int y)
		{
			return (adjMat[x, y] != 0) ? 1 : 0;
		}
		
		public void addEdge(int x, int y)
		{
			adjMat[x, y] = 1;
			adjMat[y, x] = 1;
		}
		
		public void deleteEdge(int x, int y)
		{
			adjMat[x, y] = 0;
			adjMat[y, x] = 0;
		}
		
		public E getNodeValue(int x)
		{
			return nodes[x];
		}
		
		public void setNodeValue(int x, E a)
		{
			nodes[x] = a;
		}
		
		public int getNumNodes()
		{
			return num_nodes;
		}
		
		public void setNumNodes(int num_nodes)
		{
			this.num_nodes = num_nodes;
		}
		
	}
}

