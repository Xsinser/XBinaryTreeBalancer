using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XBinaryTreeBalancer
{
    public class TreeBalancer
    {
        public Node CreateTree(List<Node> nodes)
        {
            var maxNodesCount = nodes.Count;
            if (maxNodesCount == 1)
                return nodes[0];

            var baseNode = new Node();
            int depthTree = (int)Math.Abs(Math.Log2(maxNodesCount));
            var numberOfNodesExceedingTree = maxNodesCount - Math.Pow(2, depthTree);
            var currentLayer = 1;
            Node[] currentNodes = new Node[maxNodesCount];
            Node[] tempNodes = new Node[maxNodesCount];
            currentNodes[0] = baseNode;
            var currentLayerElementsCount = Math.Pow(2, currentLayer - 1);
            while (currentLayer <= depthTree)
            {
                for (int i = 0; i < currentLayerElementsCount; i++)
                {
                    var currentNode = currentNodes[i];
                    var leftNode = new Node();
                    var rightNode = new Node();

                    currentNode.LeftNode = leftNode;
                    currentNode.RightNode = rightNode;
                    var index = 2 * i;
                    tempNodes[index] = leftNode;
                    tempNodes[index + 1] = rightNode;
                }

                currentNodes = tempNodes;
                currentLayer++;
                currentLayerElementsCount = Math.Pow(2, currentLayer - 1);
            }
            List<Node> removedNodes = new List<Node>();

            for (int i = (int)(maxNodesCount - numberOfNodesExceedingTree - 1); i < currentLayerElementsCount; i++)
                removedNodes.Add(currentNodes[i]);

            var firstRemovedItemIndex = (int)(maxNodesCount - numberOfNodesExceedingTree - 1);
            var iterator = firstRemovedItemIndex;
            foreach (var item in removedNodes)
            {
                var currentNode = item;
                var leftNode = new Node();
                var rightNode = new Node();

                currentNode.LeftNode = leftNode;
                currentNode.RightNode = rightNode;
                currentNodes[iterator] = leftNode;
                iterator++;
                currentNodes[iterator] = rightNode;
                iterator++;
            }

            for (int i = 0; i < maxNodesCount; i++)
                currentNodes[i] = nodes[i];

            return baseNode;
        }
    }
}
