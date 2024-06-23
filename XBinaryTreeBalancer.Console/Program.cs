
using XBinaryTreeBalancer;

List<Node> nodes3 = [new Node(), new Node(), new Node(),]; // done
List<Node> nodes6 = [new Node(), new Node(), new Node(), new Node(), new Node(), new Node(),]; // done
List<Node> nodes7 = [new Node(), new Node(), new Node(), new Node(), new Node(), new Node(), new Node(),]; // done


TreeBalancer treeBalancer = new TreeBalancer();
var node3 = treeBalancer.CreateTree(nodes3);
var node6 = treeBalancer.CreateTree(nodes6);
var node7 = treeBalancer.CreateTree(nodes7);
var a = 1;